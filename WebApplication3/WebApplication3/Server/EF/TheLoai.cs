namespace WebApplication3.Server.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TheLoai")]
    public partial class TheLoai
    {
        public int id { get; set; }

        [StringLength(200)]
        public string description { get; set; }

        public int? displayOrder { get; set; }

        public DateTime? createdDate { get; set; }

        [StringLength(20)]
        public string createdBy { get; set; }

        public bool? status { get; set; }

        public bool? showOnHome { get; set; }

        [StringLength(50)]
        public string categoryName { get; set; }

        public DateTime? minifyDate { get; set; }
    }
}
