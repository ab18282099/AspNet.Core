using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;

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
            // NLog: setup the logger first to catch all errors
            NLog.Logger logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();

            try
            {
                logger.Debug("Main loading...");

                // 建立 WebHost 並且執行
                CreateWebHost(args).Run();
            }
            catch (Exception exception)
            {
                // NLog: catch setup errors
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
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
                          .ConfigureLogging(logging =>
                           {
                               logging.ClearProviders();
                               logging.SetMinimumLevel(LogLevel.Trace);
                           })
                          .UseNLog()
                          .UseUrls(configuration["urls"])
                          .Build();
        }
    }
}