namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhotoAlbum")]
    public partial class PhotoAlbum
    {
        public int PhotoAlbumID { get; set; }

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

        public bool? IsAvailable { get; set; }

        public int? Priority { get; set; }

        public int? PhotoAlbumCategoryID { get; set; }

        public virtual PhotoAlbumCategory PhotoAlbumCategory { get; set; }
    }
}
