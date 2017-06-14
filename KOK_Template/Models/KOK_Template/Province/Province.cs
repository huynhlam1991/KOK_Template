namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Province")]
    public partial class Province
    {
        public int ProvinceID { get; set; }

        [StringLength(50)]
        public string ProvinceName { get; set; }

        public bool? IsAvailable { get; set; }

        public int? Priority { get; set; }

        [StringLength(3)]
        public string ShortName { get; set; }

        public int? CountryID { get; set; }

        [Column(TypeName = "money")]
        public decimal? ShippingPrice { get; set; }
    }
}
