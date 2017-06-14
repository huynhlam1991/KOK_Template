namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Partner")]
    public partial class Partner
    {
        public int PartnerID { get; set; }

        [StringLength(100)]
        public string PartnerName { get; set; }

        [StringLength(100)]
        public string PartnerNameEn { get; set; }

        [StringLength(100)]
        public string PartnerImage { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(100)]
        public string LinkWebsite { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? Priority { get; set; }

        public bool? IsAvailable { get; set; }
    }
}
