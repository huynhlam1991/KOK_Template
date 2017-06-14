namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductSizeColor")]
    public partial class ProductSizeColor
    {
        public int ProductSizeColorID { get; set; }

        public int? ProductID { get; set; }

        public int? ProductOptionCategoryID { get; set; }

        public int? ProductLengthID { get; set; }

        public int? Quantity { get; set; }

        public int? QuantitySale { get; set; }

        public bool? InStock { get; set; }

        public bool? IsAvailable { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? Priority { get; set; }
    }
}
