using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace AspNet.Core.Web
{
    /// <summary>
    /// 應用程式主體
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 建構子
        /// </summary>
        protected Program()
        {
        }

        /// <summary>
        /// 主程式
        /// </summary>
        /// <param name="args">參數</param>
        public static void Main(string[] args)
        {
            // 建立 WebHost 並且執行
            CreateWebHost(args).Run();
        }

        /// <summary>
        /// 建立 WebHost 並且使用 Startup 啟動
        /// </summary>
        /// <param name="args">參數</param>
        /// <returns>IWebHost</returns>
        public static IWebHost CreateWebHost(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().AddCommandLine(args).Build();

            return WebHost.CreateDefaultBuilder(args)
                          .UseIISIntegration()
                          .UseStartup<Startup>()
                          .UseUrls(configuration["urls"])
                          .Build();
        }
    }
}