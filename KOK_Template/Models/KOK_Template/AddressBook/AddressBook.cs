namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AddressBook")]
    public partial class AddressBook
    {
        public int AddressBookID { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(20)]
        public string HomePhone { get; set; }

        [StringLength(20)]
        public string CellPhone { get; set; }

        [StringLength(20)]
        public string Fax { get; set; }

        public bool? ReceiveEmail { get; set; }

        [StringLength(256)]
        public string UserName { get; set; }

        [StringLength(200)]
        public string Company { get; set; }

        [StringLength(200)]
        public string Address1 { get; set; }

        [StringLength(200)]
        public string Address2 { get; set; }

        [StringLength(20)]
        public string ZipCode { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        public int? CountryID { get; set; }

        public int? ProvinceID { get; set; }

        public int? DistrictID { get; set; }

        public bool? IsPrimary { get; set; }

        public bool? IsPrimaryBilling { get; set; }

        public bool? IsPrimaryShipping { get; set; }

        [StringLength(256)]
        public string RoleName { get; set; }

        public bool? Gender { get; set; }

        public DateTime? Birthday { get; set; }

        [StringLength(200)]
        public string ImageName { get; set; }
    }
}
