namespace WebApplication3.Server.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [Key]
        public int spId { get; set; }

        public int categoryId { get; set; }

        [StringLength(100)]
        public string spName { get; set; }

        [StringLength(20)]
        public string color { get; set; }

        [StringLength(20)]
        public string size { get; set; }

        [Column(TypeName = "money")]
        public decimal? price { get; set; }

        [StringLength(10)]
        public string type { get; set; }

        public int? viewCount { get; set; }

        public bool? userManual { get; set; }

        public int? quantitySold { get; set; }

        [StringLength(100)]
        public string image { get; set; }

        [StringLength(50)]
        public string moreImages { get; set; }

        [StringLength(50)]
        public string seoTitile { get; set; }

        public DateTime? createdAt { get; set; }

        [StringLength(20)]
        public string createdBy { get; set; }

        public int? inventory { get; set; }

        public bool? status { get; set; }

        [StringLength(500)]
        public string description { get; set; }

        public int? warranty { get; set; }

        [StringLength(20)]
        public string material { get; set; }

        [Column(TypeName = "money")]
        public decimal? comparePrice { get; set; }

        public DateTime? minifyDate { get; set; }

        [StringLength(20)]
        public string categoryName { get; set; }

        public bool? isDeleted { get; set; }

        public bool? isActive { get; set; }

        [StringLength(20)]
        public string promotion { get; set; }
    }
}
