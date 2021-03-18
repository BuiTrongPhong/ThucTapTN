namespace WebApplication3.Server.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [StringLength(50)]
        public string firstName { get; set; }

        [StringLength(20)]
        public string lastName { get; set; }

        public int? age { get; set; }

        [StringLength(200)]
        public string address { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        public bool? isAdmin { get; set; }

        [StringLength(100)]
        public string password { get; set; }

        public DateTime? createdAt { get; set; }

        public DateTime? modifyDate { get; set; }

        public bool? status { get; set; }

        [Key]
        public int userId { get; set; }

        [StringLength(11)]
        public string phone { get; set; }

        [StringLength(20)]
        public string province { get; set; }

        [StringLength(20)]
        public string district { get; set; }

        [StringLength(20)]
        public string commune { get; set; }

        [StringLength(100)]
        public string confirmPassword { get; set; }
    }
}
