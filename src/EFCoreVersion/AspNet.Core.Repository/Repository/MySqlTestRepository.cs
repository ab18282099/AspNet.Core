using AspNet.Core.Repository.Models;
using Power.Repository.EFCore;

namespace AspNet.Core.Repository
{
    /// <summary>
    /// MySql 測試資料儲存庫
    /// </summary>
    public class MySqlTestRepository : RepositoryGeneric<MySqlTest, MySqlDbContext>, IMySqlTestRepository
    {
        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="factory">DbContext 工廠</param>
        public MySqlTestRepository(
            IMySqlDbContextFactory<MySqlDbContext> factory) : base(factory)
        {
        }
    }
}