namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhotoAlbumCategory")]
    public partial class PhotoAlbumCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhotoAlbumCategory()
        {
            PhotoAlbums = new HashSet<PhotoAlbum>();
        }

        public int PhotoAlbumCategoryID { get; set; }

        [StringLength(200)]
        public string ImageName { get; set; }

        [StringLength(100)]
        public string PhotoAlbumCategoryName { get; set; }

        [StringLength(100)]
        public string PhotoAlbumCategoryNameEn { get; set; }

        public bool? IsShowOnMenu { get; set; }

        public bool? IsShowOnHomePage { get; set; }

        public bool? IsAvailable { get; set; }

        public int? Priority { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhotoAlbum> PhotoAlbums { get; set; }
    }
}
