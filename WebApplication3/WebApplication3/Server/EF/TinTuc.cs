namespace WebApplication3.Server.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int newsId { get; set; }

        [StringLength(150)]
        public string title { get; set; }

        public DateTime? createdAt { get; set; }

        [StringLength(20)]
        public string createdBy { get; set; }

        [StringLength(200)]
        public string link { get; set; }

        [StringLength(1)]
        public string status { get; set; }
    }
}
