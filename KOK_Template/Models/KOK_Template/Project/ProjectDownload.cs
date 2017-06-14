namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProjectDownload")]
    public partial class ProjectDownload
    {
        public int ProjectDownloadID { get; set; }

        public int? ProjectID { get; set; }

        [StringLength(100)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string FileNameEn { get; set; }

        [StringLength(100)]
        public string LinkDownload { get; set; }

        public bool? IsAvailable { get; set; }

        public int? Priority { get; set; }

        public virtual Project Project { get; set; }
    }
}
