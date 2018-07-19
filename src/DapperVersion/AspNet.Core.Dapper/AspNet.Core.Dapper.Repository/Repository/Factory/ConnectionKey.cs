namespace AspNet.Core.Dapper.Repository
{
    /// <summary>
    /// 連線鍵值
    /// </summary>
    public enum ConnectionKey
    {
        /// <summary>
        /// 本機 PostgreSql
        /// </summary>
        PostgresLocal = 1,

        /// <summary>
        /// Docker PostgerSql
        /// </summary>
        PostgresDocker,

        /// <summary>
        /// 本機 MySql
        /// </summary>
        MySqlLocal
    }
}