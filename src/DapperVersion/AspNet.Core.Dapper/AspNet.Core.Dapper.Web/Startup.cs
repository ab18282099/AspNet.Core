using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Power.Mvc.Helper;
using Power.Mvc.Helper.Extensions;
using System;
using System.Linq;
using System.Reflection;

namespace AspNet.Core.Dapper.Web
{
    /// <summary>
    /// Startup WebApp 啟動類別
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="configuration">Represents a set of key/value application configuration properties.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Autofac DI 容器
        /// </summary>
        public IContainer ApplicationContainer { get; private set; }

        /// <summary>
        /// Represents a set of key/value application configuration properties.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        /// <returns>IServiceProvider</returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            ContainerBuilder builder = new ContainerBuilder();

            // 將 services 容器內已有的類型註冊資訊倒入 autofac 容器
            builder.Populate(services);

            // 取得排序後的 TypeRegister
            IOrderedEnumerable<ITypeRegister> registrars
                = Assembly.GetExecutingAssembly()
                          .GetReferencedAssemblies()
                          .Select(Assembly.Load)
                          .Concat(new Assembly[]
                           {
                               // 此處載入 Web 專案未引用到之專案
                               Assembly.Load("AspNet.Core.Dapper.Web"), 
                           })
                          .SelectMany(p => p.ExportedTypes.Where(s => s.IsAssignableTo<ITypeRegister>() && !s.IsInterface))
                          .Select(p => (ITypeRegister)Activator.CreateInstance(p))
                          .OrderBy(p => p.Seq);

            // 個別進行註冊
            foreach (ITypeRegister registrar in registrars)
            {
                registrar.RegisterTypes(builder);
            }

            // 記錄非預期註冊的型別
            builder.DumpUnexpectRegistration();

            IContainer container = builder.Build();

            // 設定套件相依性解析
            PackageDiResolver.Current.SetAutofacContainer(container);
            this.ApplicationContainer = container;

            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Defines a class that provides the mechanisms to configure an application's request pipeline.</param>
        /// <param name="env">Provides information about the web hosting environment an application is running in.</param>
        /// <param name="appLifetime">Allows consumers to perform cleanup during a graceful shutdown.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            // router 設定
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // If you want to dispose of resources that have been resolved in the
            // application container, register for the "ApplicationStopped" event.
            // You can only do this if you have a direct reference to the container,
            // so it won't work with the above ConfigureContainer mechanism.
            appLifetime.ApplicationStopped.Register(() => this.ApplicationContainer.Dispose());
        }
    }
}