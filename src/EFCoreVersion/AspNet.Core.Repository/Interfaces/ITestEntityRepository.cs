using AspNet.Core.Repository.Models;
using Power.Repository.EFCore;

namespace AspNet.Core.Repository
{
    /// <summary>
    /// 測試 Table 儲存庫介面
    /// </summary>
    public interface ITestEntityRepository : IRepositoryGeneric<TestEntity, PostgreSqlDbContext>
    {
    }
}