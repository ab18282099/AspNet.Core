﻿using AspNet.Core.Dapper.Repository.Models;
using Power.Repository.Dapper;

namespace AspNet.Core.Dapper.Repository
{
    /// <summary>
    /// MySql 測試資料儲存庫
    /// </summary>
    public class MySqlTestRepository : RepositoryGeneric<MySqlTest>, IMySqlTestRepository
    {
        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="factory">連線工廠</param>
        public MySqlTestRepository(IMySqlConnectionFactory factory) : base(factory)
        {
        }
    }
}