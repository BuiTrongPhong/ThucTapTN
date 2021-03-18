namespace WebApplication3.Server.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShippingMethod")]
    public partial class ShippingMethod
    {
        [StringLength(100)]
        public string id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        public DateTime? createAt { get; set; }

        public DateTime? updateAt { get; set; }

        [Column(TypeName = "money")]
        public decimal? price { get; set; }
    }
}
