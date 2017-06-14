namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductOfSame")]
    public partial class ProductOfSame
    {
        public int ProductOfSameID { get; set; }

        public int? ProductID { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? IsAvailable { get; set; }

        public int? Priority { get; set; }

        public int? ProductParentID { get; set; }

        public virtual Product Product { get; set; }
    }
}
