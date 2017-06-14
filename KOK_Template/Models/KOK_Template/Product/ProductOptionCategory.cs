namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductOptionCategory")]
    public partial class ProductOptionCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductOptionCategory()
        {
            ProductOptions = new HashSet<ProductOption>();
        }

        public int ProductOptionCategoryID { get; set; }

        [StringLength(100)]
        public string ProductOptionCategoryName { get; set; }

        [StringLength(100)]
        public string ProductOptionCategoryNameEn { get; set; }

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

        public int? ParentID { get; set; }

        public int? SortOrder { get; set; }

        public bool? IsShowOnMenu { get; set; }

        public bool? IsShowOnHomePage { get; set; }

        public bool? IsAvailable { get; set; }

        public int? ProductID { get; set; }

        public virtual Product Product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOption> ProductOptions { get; set; }
    }
}
