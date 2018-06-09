using Power.Repository.EFCore;

namespace AspNet.Core.Repository
{
    /// <summary>
    /// PostgreSqlDbContext 工廠
    /// </summary>
    public class PostgreSqlDbContextFactory : DbContextFactoryBase<PostgreSqlDbContext>, IPostgreSqlDbContextFactory<PostgreSqlDbContext>
    {
        /// <summary>
        /// 連線字串 Key 值
        /// </summary>
        protected override string ConnectionKey { get; set; } = "PostgreSqlDbContext";
    }
}