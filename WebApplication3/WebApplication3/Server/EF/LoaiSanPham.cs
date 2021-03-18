namespace WebApplication3.Server.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiSanPham")]
    public partial class LoaiSanPham
    {
        [Key]
        public int typeId { get; set; }

        [StringLength(50)]
        public string typeName { get; set; }

        public bool? status { get; set; }
    }
}
