namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rating")]
    public partial class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        public int Rating1 { get; set; }

        public int Rating2 { get; set; }

        public int Rating3 { get; set; }

        public int Rating4 { get; set; }

        public int Rating5 { get; set; }

        public virtual Product Product { get; set; }
    }
}
