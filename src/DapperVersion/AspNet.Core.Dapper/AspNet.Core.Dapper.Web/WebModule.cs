using Autofac;
using Power.Mvc.Helper;
using Power.Mvc.Helper.Extensions;
using System;

namespace AspNet.Core.Dapper.Web
{
    /// <summary>
    /// Base class for user-defined modules
    /// </summary>
    public class WebModule : Module
    {
        /// <summary>
        /// SettingHelper
        /// </summary>
        public string SettingHelper { get; set; }

        /// <summary>
        /// CacheHelper
        /// </summary>
        public string CacheHelper { get; set; }

        /// <summary>
        /// 加解密
        /// </summary>
        public string EncryptHelper { get; set; }

        /// <summary>
        /// Add registrations to the container
        /// </summary>
        /// <param name="builder">Initializes a new instance of the Autofac.ContainerBuilder class.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder
               .RegisterType(Type.GetType(this.SettingHelper))
               .As<ISettingHelper>()
               .InstancePerLifetimeScope()
               .LogExpectRegistration();

            // 快取使用 redis server，因此在此使用單一實例，使連線個體為單一實例
            builder
               .RegisterType(Type.GetType(this.CacheHelper))
               .As<ICacheHelper>()
               .SingleInstance()
               .LogExpectRegistration();

            builder
               .RegisterType(Type.GetType(this.EncryptHelper))
               .Keyed<ISymmetricEncryptHelper>(EncryptType.AES)
               .InstancePerLifetimeScope()
               .LogExpectRegistration();
        }
    }
}