using AspNet.Core.Dapper.Repository.Models;
using Power.Repository.Dapper;

namespace AspNet.Core.Dapper.Repository
{
    /// <summary>
    /// MySql 測試資料儲存庫介面
    /// </summary>
    public interface IMySqlTestRepository : IRepositoryGeneric<MySqlTest>
    {
    }
}