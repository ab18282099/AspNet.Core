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
        /// 建構子
        /// </summary>
        /// <param name="testEntityRepository">測試資料儲存庫(PostgreSql)</param>
        public HealthController(
            ITestEntityRepository testEntityRepository)
        {
            this.TestEntityRepository = testEntityRepository;
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
    }
}