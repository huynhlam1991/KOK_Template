namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductOption")]
    public partial class ProductOption
    {
        public int ProductOptionID { get; set; }

        [StringLength(100)]
        public string ImageName { get; set; }

        [StringLength(500)]
        public string MetaTittle { get; set; }

        [StringLength(1000)]
        public string MetaDescription { get; set; }

        [StringLength(100)]
        public string ProductOptionTitle { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public string Content { get; set; }

        [StringLength(500)]
        public string MetaTittleEn { get; set; }

        [StringLength(1000)]
        public string MetaDescriptionEn { get; set; }

        [StringLength(100)]
        public string ProductOptionTitleEn { get; set; }

        [StringLength(1000)]
        public string DescriptionEn { get; set; }

        public string ContentEn { get; set; }

        [StringLength(200)]
        public string TagEn { get; set; }

        public int? ProductOptionCategoryID { get; set; }

        [StringLength(200)]
        public string Tag { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? Priority { get; set; }

        public bool? IsShowOnHomePage { get; set; }

        public bool? IsHot { get; set; }

        public bool? IsNew { get; set; }

        public bool? IsAvailable { get; set; }

        public virtual ProductOptionCategory ProductOptionCategory { get; set; }
    }
}
