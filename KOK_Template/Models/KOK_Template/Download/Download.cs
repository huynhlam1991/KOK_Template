namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Download")]
    public partial class Download
    {
        public int DownloadID { get; set; }

        [StringLength(200)]
        public string ImageName { get; set; }

        [StringLength(200)]
        public string FilePath { get; set; }

        [StringLength(200)]
        public string DownloadName { get; set; }

        [StringLength(200)]
        public string DownloadNameEn { get; set; }

        public int? DownloadCategoryID { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? IsAvailable { get; set; }

        public int? Priority { get; set; }

        public virtual DownloadCategory DownloadCategory { get; set; }
    }
}
