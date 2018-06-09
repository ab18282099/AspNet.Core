using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNet.Core.Dapper.Repository.Models
{
    /// <summary>
    /// MySql 測試實體資料
    /// </summary>
    [Table("kingoflock_test")]
    public class MySqlTest
    {
        /// <summary>
        /// 編號
        /// </summary>
        [Key]
        [Column("test_id")]
        public int Id { get; set; }

        /// <summary>
        /// 名稱
        /// </summary>
        [Column("test_name")]
        public string Name { get; set; }
    }
}