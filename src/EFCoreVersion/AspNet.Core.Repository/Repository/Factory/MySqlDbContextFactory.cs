using Power.Repository.EFCore;

namespace AspNet.Core.Repository
{
    /// <summary>
    /// MySqlDbContext 工廠
    /// </summary>
    public class MySqlDbContextFactory : DbContextFactoryBase<MySqlDbContext>, IMySqlDbContextFactory<MySqlDbContext>
    {
        /// <summary>
        /// 連線字串 Key 值
        /// </summary>
        protected override string ConnectionKey { get; set; } = "MySqlDbContext";
    }
}