namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WishList")]
    public partial class WishList
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(256)]
        public string UserName { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(200)]
        public string ImageName { get; set; }

        [StringLength(200)]
        public string ProductName { get; set; }

        [StringLength(200)]
        public string ProductNameEn { get; set; }

        [StringLength(50)]
        public string ProductCode { get; set; }

        public int? ProductOptionCategoryID { get; set; }

        [StringLength(200)]
        public string ProductOptionCategoryName { get; set; }

        public int? ProductLengthID { get; set; }

        [StringLength(200)]
        public string ProductLengthName { get; set; }

        public int? ProductSizeColorID { get; set; }

        public int? QuantityList { get; set; }
    }
}
