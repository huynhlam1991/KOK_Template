namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VideoCategory")]
    public partial class VideoCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VideoCategory()
        {
            Videos = new HashSet<Video>();
        }

        public int VideoCategoryID { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(500)]
        public string DescriptionEn { get; set; }

        public string Content { get; set; }

        public string ContentEn { get; set; }

        [StringLength(100)]
        public string MetaTitle { get; set; }

        [StringLength(100)]
        public string MetaTitleEn { get; set; }

        [StringLength(300)]
        public string MetaDescription { get; set; }

        [StringLength(300)]
        public string MetaDescriptionEn { get; set; }

        [StringLength(100)]
        public string ImageName { get; set; }

        [StringLength(100)]
        public string VideoCategoryName { get; set; }

        [StringLength(100)]
        public string VideoCategoryNameEn { get; set; }

        public bool? IsShowOnMenu { get; set; }

        public bool? IsShowOnHomePage { get; set; }

        public bool? IsAvailable { get; set; }

        public int? Priority { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Video> Videos { get; set; }
    }
}
