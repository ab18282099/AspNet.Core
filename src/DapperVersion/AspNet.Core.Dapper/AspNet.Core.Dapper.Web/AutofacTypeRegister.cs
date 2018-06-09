using System.IO;
using Autofac;
using Power.Mvc.Helper;
using Power.Mvc.Helper.Extensions;

namespace AspNet.Core.Dapper.Web
{
    /// <summary>
    /// 類型註冊
    /// </summary>
    public class AutofacTypeRegister : ITypeRegister
    {
        /// <summary>
        /// 註冊順序
        /// </summary>
        public int Seq => 10;

        /// <summary>
        /// 註冊類型
        /// </summary>
        /// <param name="builder">Used to build an <see cref="T:Autofac.IContainer" /> from component registrations.</param>
        public void RegisterTypes(ContainerBuilder builder)
        {
            // 預設抓根目錄的 webmodule.json
            builder.RegisterWebModule(Path.Combine(Directory.GetCurrentDirectory(), "webmodule.json"));
        }
    }
}