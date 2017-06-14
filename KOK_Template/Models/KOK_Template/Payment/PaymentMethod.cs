namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaymentMethod")]
    public partial class PaymentMethod
    {
        [StringLength(20)]
        public string PaymentMethodID { get; set; }

        [StringLength(50)]
        public string PaymentMethodName { get; set; }

        [StringLength(50)]
        public string PaymentMethodNameEn { get; set; }
    }
}
