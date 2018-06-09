using Power.Repository.Dapper;

namespace AspNet.Core.Dapper.Repository
{
    /// <summary>
    /// MySql 連線工廠
    /// </summary>
    public class MySqlConnectionFactory : MySqlDbConnectionFactoryBase
    {
        /// <summary>
        /// 連線字串鍵值
        /// </summary>
        protected override string ConnectionKey { get; set; } = "MySqlLocal";
    }
}