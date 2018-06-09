using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNet.Core.Repository.Models
{
    /// <summary>
    /// 測試用 Table 實體資料
    /// </summary>
    [Table("kingoflock_testentity")]
    public class TestEntity
    {
        /// <summary>
        /// 編號
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("testentity_id")]
        public int Id { get; set; }

        /// <summary>
        /// 名稱
        /// </summary>
        [Column("testentity_name")]
        public string Name { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [Column("testentity_value")]
        public int Value { get; set; }
    }
}