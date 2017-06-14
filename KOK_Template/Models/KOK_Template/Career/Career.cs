namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Career")]
    public partial class Career
    {
        public int CareerID { get; set; }

        [StringLength(100)]
        public string ImageName { get; set; }

        [StringLength(500)]
        public string MetaTittle { get; set; }

        [StringLength(1000)]
        public string MetaDescription { get; set; }

        [StringLength(100)]
        public string CareerTitle { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public string Content { get; set; }

        [StringLength(200)]
        public string Tag { get; set; }

        [StringLength(500)]
        public string MetaTittleEn { get; set; }

        [StringLength(1000)]
        public string MetaDescriptionEn { get; set; }

        [StringLength(100)]
        public string CareerTitleEn { get; set; }

        [StringLength(1000)]
        public string DescriptionEn { get; set; }

        public string ContentEn { get; set; }

        [StringLength(200)]
        public string TagEn { get; set; }

        public int? CareerCategoryID { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? Priority { get; set; }

        public bool? IsShowOnHomePage { get; set; }

        public bool? IsAvailable { get; set; }

        public virtual CareerCategory CareerCategory { get; set; }
    }
}
