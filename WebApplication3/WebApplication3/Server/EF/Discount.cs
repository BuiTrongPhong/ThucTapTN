namespace WebApplication3.Server.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Discount")]
    public partial class Discount
    {
        public int discountId { get; set; }

        [StringLength(100)]
        public string discountName { get; set; }

        public int? value { get; set; }

        [StringLength(10)]
        public string code { get; set; }

        public DateTime? createdAt { get; set; }

        public DateTime? startDate { get; set; }

        public DateTime? endDate { get; set; }

        public int? applyToProduct { get; set; }

        public int? limit { get; set; }

        public int? applyToCustomer { get; set; }

        [MaxLength(50)]
        public byte[] type { get; set; }

        public bool? status { get; set; }

        [StringLength(50)]
        public string productName { get; set; }

        [StringLength(50)]
        public string customerName { get; set; }
    }
}
