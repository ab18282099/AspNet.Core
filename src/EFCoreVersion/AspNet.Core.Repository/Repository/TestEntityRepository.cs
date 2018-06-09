using AspNet.Core.Repository.Models;
using Power.Repository.EFCore;

namespace AspNet.Core.Repository
{
    /// <summary>
    /// 測試 Table 儲存庫
    /// </summary>
    public class TestEntityRepository : RepositoryGeneric<TestEntity, PostgreSqlDbContext>, ITestEntityRepository
    {
        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="factory">DbContext 工廠</param>
        public TestEntityRepository(
            IPostgreSqlDbContextFactory<PostgreSqlDbContext> factory) : base(factory)
        {
        }
    }
}