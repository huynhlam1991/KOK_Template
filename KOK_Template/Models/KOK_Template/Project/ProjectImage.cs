namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProjectImage")]
    public partial class ProjectImage
    {
        public int ProjectImageID { get; set; }

        [StringLength(200)]
        public string ImageName { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Descripttion { get; set; }

        [StringLength(200)]
        public string TitleEn { get; set; }

        [StringLength(500)]
        public string DescripttionEn { get; set; }

        public int? ProjectID { get; set; }

        public bool? IsAvailable { get; set; }

        public int? Priority { get; set; }

        public virtual Project Project { get; set; }
    }
}
