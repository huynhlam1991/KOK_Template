namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [StringLength(10)]
        public string OrderID { get; set; }

        [StringLength(256)]
        public string UserName { get; set; }

        public int? OrderStatusID { get; set; }

        public int? ShippingStatusID { get; set; }

        [StringLength(20)]
        public string PaymentMethodID { get; set; }

        public int? BillingAddressID { get; set; }

        public int? ShippingAddressID { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? Commission { get; set; }

        public int? ServiceID { get; set; }

        public int? DeliveryMethodsID { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [StringLength(200)]
        public string DeliveryAddress { get; set; }

        public int? CustomerAddressID { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        public int? PayStatusID { get; set; }
    }
}
