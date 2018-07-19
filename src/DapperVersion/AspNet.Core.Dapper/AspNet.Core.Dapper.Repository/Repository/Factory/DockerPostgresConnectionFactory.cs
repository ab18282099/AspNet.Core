using Power.Repository.Dapper;

namespace AspNet.Core.Dapper.Repository
{
    /// <summary>
    /// Docker PostgreSql 連線工廠
    /// </summary>
    public class DockerPostgresConnectionFactory : PostgreSqlConnectionFactoryBase
    {
        /// <summary>
        /// 連線字串鍵值
        /// </summary>
        protected override string ConnectionKey { get; set; } = "PostgreSqlDocker";
    }
}