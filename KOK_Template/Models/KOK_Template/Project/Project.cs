namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project")]
    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            ProjectDownloads = new HashSet<ProjectDownload>();
            ProjectImages = new HashSet<ProjectImage>();
            ProjectVideos = new HashSet<ProjectVideo>();
        }

        public int ProjectID { get; set; }

        [StringLength(100)]
        public string ImageName { get; set; }

        [StringLength(500)]
        public string MetaTittle { get; set; }

        [StringLength(1000)]
        public string MetaDescription { get; set; }

        [StringLength(100)]
        public string ProjectTitle { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public string Content { get; set; }

        [StringLength(500)]
        public string MetaTittleEn { get; set; }

        [StringLength(1000)]
        public string MetaDescriptionEn { get; set; }

        [StringLength(100)]
        public string ProjectTitleEn { get; set; }

        [StringLength(1000)]
        public string DescriptionEn { get; set; }

        public string ContentEn { get; set; }

        [StringLength(200)]
        public string TagEn { get; set; }

        public int? ProjectCategoryID { get; set; }

        [StringLength(200)]
        public string Tag { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? IsHot { get; set; }

        public bool? IsNew { get; set; }

        public bool? IsShowOnHomePage { get; set; }

        public bool? IsAvailable { get; set; }

        public int? Priority { get; set; }

        public virtual ProjectCategory ProjectCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectDownload> ProjectDownloads { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectImage> ProjectImages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectVideo> ProjectVideos { get; set; }
    }
}
