namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductDownload")]
    public partial class ProductDownload
    {
        public int ProductDownloadID { get; set; }

        public int? ProductID { get; set; }

        [StringLength(100)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string FileNameEn { get; set; }

        [StringLength(100)]
        public string LinkDownload { get; set; }

        public bool? IsAvailable { get; set; }

        public int? Priority { get; set; }

        public virtual Product Product { get; set; }
    }
}
