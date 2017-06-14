namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("District")]
    public partial class District
    {
        public int DistrictID { get; set; }

        [StringLength(100)]
        public string DistrictName { get; set; }

        public int? ProvinceID { get; set; }

        public bool? IsAvailable { get; set; }

        public int? Priority { get; set; }

        [Column(TypeName = "money")]
        public decimal? ShippingPrice { get; set; }

        [StringLength(100)]
        public string DistrictNameEn { get; set; }
    }
}
