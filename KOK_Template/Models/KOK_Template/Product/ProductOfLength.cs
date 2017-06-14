namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductOfLength")]
    public partial class ProductOfLength
    {
        public int ProductOfLengthID { get; set; }

        public int? ProductID { get; set; }

        public int? ProductLengthID { get; set; }

        public bool? IsAvailable { get; set; }

        public int? Priority { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
