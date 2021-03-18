namespace WebApplication3.Server.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        internal ICollection<ChiTietDonHang> ChiTietDonHangs;

        [Key]
        public int orderId { get; set; }

        public int? userId { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        [StringLength(100)]
        public string note { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        public int? discountId { get; set; }

        public DateTime? createdAt { get; set; }

        [StringLength(100)]
        public string customerName { get; set; }
    }
}
