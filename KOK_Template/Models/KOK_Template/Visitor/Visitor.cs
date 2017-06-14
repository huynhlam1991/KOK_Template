namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Visitor")]
    public partial class Visitor
    {
        public int VisitorID { get; set; }

        public DateTime? CreateDate { get; set; }

        public long? Visitors { get; set; }
    }
}
