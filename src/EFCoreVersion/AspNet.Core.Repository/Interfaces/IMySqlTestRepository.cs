using AspNet.Core.Repository.Models;
using Power.Repository.EFCore;

namespace AspNet.Core.Repository
{
    /// <summary>
    /// MySql 測試資料儲存庫介面
    /// (目前可能因為版本問題，MySql 暫時無法正常存取)
    /// </summary>
    public interface IMySqlTestRepository : IRepositoryGeneric<MySqlTest, MySqlDbContext>
    {
    }
}