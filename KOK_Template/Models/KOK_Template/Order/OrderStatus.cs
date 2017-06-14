namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderStatus
    {
        [Key]
        public int OrderStatusID { get; set; }

        [StringLength(100)]
        public string OrderStatusName { get; set; }

        [StringLength(100)]
        public string OrderStatusNameEn { get; set; }

        public bool? IsAvailable { get; set; }
    }
}
