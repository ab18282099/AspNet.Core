using AspNet.Core.Repository;
using AspNet.Core.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspNet.Core.Web.Controllers
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
        /// MySql 測試資料儲存庫介面
        /// </summary>
        private readonly IMySqlTestRepository MySqlTestRepository;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="testEntityRepository">測試資料儲存庫(PostgreSql)</param>
        /// <param name="mySqlTestRepository">MySql 測試資料儲存庫介面</param>
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
            List<TestEntity> data = this.TestEntityRepository.GetAll();

            return this.Json(data);
        }

        /// <summary>
        /// 測試取得 MySql 測試資料集合
        /// </summary>
        /// <returns>json response</returns>
        [HttpGet]
        public IActionResult MySqlTest()
        {
            List<MySqlTest> data = this.MySqlTestRepository.GetAll();

            return this.Json(data);
        }
    }
}