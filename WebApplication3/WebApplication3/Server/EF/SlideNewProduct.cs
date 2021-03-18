namespace WebApplication3.Server.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SlideNewProduct")]
    public partial class SlideNewProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int slideId { get; set; }

        public int spId { get; set; }

        public int? position { get; set; }

        public bool? status { get; set; }

        public DateTime? createdAt { get; set; }

        public DateTime? modifyDate { get; set; }

        [StringLength(150)]
        public string title { get; set; }

        [StringLength(20)]
        public string shoeName { get; set; }

        public bool isActive { get; set; }

        [StringLength(10)]
        public string description { get; set; }
    }
}
