namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PayStatus
    {
        [Key]
        public int PayStatusID { get; set; }

        [StringLength(100)]
        public string PayStatusName { get; set; }

        [StringLength(100)]
        public string PayStatusNameEn { get; set; }

        public bool? IsAvailable { get; set; }
    }
}
