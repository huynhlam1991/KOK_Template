namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DeliveryMethod
    {
        [Key]
        public int DeliveryMethodsID { get; set; }

        [StringLength(100)]
        public string DeliveryMethodsName { get; set; }

        [StringLength(100)]
        public string DeliveryMethodsNameEn { get; set; }

        public bool? IsAvailable { get; set; }
    }
}
