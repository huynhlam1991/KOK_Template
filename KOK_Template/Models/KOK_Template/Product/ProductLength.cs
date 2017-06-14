namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductLength")]
    public partial class ProductLength
    {
        public int ProductLengthID { get; set; }

        public int? ProductID { get; set; }

        [StringLength(200)]
        public string ProductLengthName { get; set; }

        [StringLength(200)]
        public string ProductLengthNameEn { get; set; }

        public bool? IsAvailable { get; set; }

        public int? Priority { get; set; }

        public DateTime? CreateDate { get; set; }

        public virtual Product Product { get; set; }
    }
}
