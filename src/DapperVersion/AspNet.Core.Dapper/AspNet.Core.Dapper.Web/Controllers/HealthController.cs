using AspNet.Core.Dapper.Repository;
using AspNet.Core.Dapper.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspNet.Core.Dapper.Web.Controllers
{
    /// <summary>
    /// 測試用控制器
    /// </summary>
    public class HealthController : Controller
    {
        /// <summary>
        /// 測試資料儲存庫(PostgreSql)
        /// </summary>
        private readonly ITestEntityRepository TestEntityRepository;

        /// <summary>
        /// 測試資料儲存庫(MySql)
        /// </summary>
        private readonly IMySqlTestRepository MySqlTestRepository;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="testEntityRepository">測試資料儲存庫(PostgreSql)</param>
        /// <param name="mySqlTestRepository">測試資料儲存庫(MySql)</param>
        public HealthController(
            ITestEntityRepository testEntityRepository,
            IMySqlTestRepository mySqlTestRepository)
        {
            this.TestEntityRepository = testEntityRepository;
            this.MySqlTestRepository = mySqlTestRepository;
        }

        /// <summary>
        /// 測試取得 PostgreSql 測試資料集合
        /// </summary>
        /// <returns>json response</returns>
        [HttpGet]
        public IActionResult PostgreSqlTest()
        {
            List<TestEntity> data = this.TestEntityRepository.GetList("WHERE 1=1").ToList();

            return this.Json(data);
        }

        /// <summary>
        /// 測試取得 MySql 測試資料集合
        /// </summary>
        /// <returns>json response</returns>
        [HttpGet]
        public IActionResult MySqlTest()
        {
            List<MySqlTest> data = this.MySqlTestRepository.GetList("WHERE 1=1").ToList();

            return this.Json(data);
        }
    }
}