namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdsBanner")]
    public partial class AdsBanner
    {
        public int AdsBannerID { get; set; }

        [StringLength(200)]
        public string FileName { get; set; }

        public int? AdsCategoryID { get; set; }

        [StringLength(200)]
        public string CompanyName { get; set; }

        [StringLength(200)]
        public string Website { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public int? Priority { get; set; }

        public bool? IsAvailable { get; set; }

        public double? Ratio { get; set; }

        public virtual AdsCategory AdsCategory { get; set; }
    }
}
