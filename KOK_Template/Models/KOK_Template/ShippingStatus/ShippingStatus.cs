namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ShippingStatus
    {
        [Key]
        public int ShippingStatusID { get; set; }

        [StringLength(50)]
        public string ShippingStatusName { get; set; }

        [StringLength(50)]
        public string ShippingStatusNameEn { get; set; }
    }
}
