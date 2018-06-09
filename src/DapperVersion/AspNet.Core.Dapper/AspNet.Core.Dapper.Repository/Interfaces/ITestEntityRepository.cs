using AspNet.Core.Dapper.Repository.Models;
using Power.Repository.Dapper;

namespace AspNet.Core.Dapper.Repository
{
    /// <summary>
    /// Postgre 測試資料儲存庫介面
    /// </summary>
    public interface ITestEntityRepository : IRepositoryGeneric<TestEntity>
    {
    }
}