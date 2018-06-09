using AspNet.Core.Dapper.Repository.Models;
using Power.Repository.Dapper;

namespace AspNet.Core.Dapper.Repository
{
    /// <summary>
    /// PostgreSql 測試資料儲存庫
    /// </summary>
    public class TestEntityRepository : RepositoryGeneric<TestEntity>, ITestEntityRepository
    {
        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="factory">連線工廠</param>
        public TestEntityRepository(IPostgreSqlConnectionFactory factory) : base(factory)
        {
        }
    }
}