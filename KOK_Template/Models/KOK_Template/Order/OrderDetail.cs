namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        public int OrderDetailID { get; set; }

        [StringLength(10)]
        public string OrderID { get; set; }

        public int? ProductID { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [StringLength(10)]
        public string Type { get; set; }

        [StringLength(256)]
        public string CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(100)]
        public string ProductColorName { get; set; }

        [StringLength(100)]
        public string ProductColorNameEn { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(100)]
        public string ProductCode { get; set; }
    }
}
