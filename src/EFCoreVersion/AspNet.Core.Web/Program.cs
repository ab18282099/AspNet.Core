using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

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
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// 建立 WebHost 並且使用 Startup 啟動
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args)
                                                                                    .UseStartup<Startup>();
    }
}