namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProjectVideo")]
    public partial class ProjectVideo
    {
        public int ProjectVideoID { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(100)]
        public string TitleEn { get; set; }

        [StringLength(500)]
        public string DescriptionEn { get; set; }

        [StringLength(100)]
        public string ImagePath { get; set; }

        [StringLength(100)]
        public string ProjectVideoPath { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? ProjectID { get; set; }

        public bool? IsAvailable { get; set; }

        public int? Priority { get; set; }

        public virtual Project Project { get; set; }
    }
}
