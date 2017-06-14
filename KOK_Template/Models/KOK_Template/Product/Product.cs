namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ProductDownloads = new HashSet<ProductDownload>();
            ProductImages = new HashSet<ProductImage>();
            ProductLengths = new HashSet<ProductLength>();
            ProductOfSames = new HashSet<ProductOfSame>();
            ProductOptionCategories = new HashSet<ProductOptionCategory>();
        }

        public int ProductID { get; set; }

        [StringLength(100)]
        public string ImageName { get; set; }

        [StringLength(500)]
        public string MetaTittle { get; set; }

        [StringLength(1000)]
        public string MetaDescription { get; set; }

        [StringLength(200)]
        public string ProductName { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public string Content { get; set; }

        [StringLength(200)]
        public string Tag { get; set; }

        [StringLength(500)]
        public string MetaTittleEn { get; set; }

        [StringLength(1000)]
        public string MetaDescriptionEn { get; set; }

        [StringLength(200)]
        public string ProductNameEn { get; set; }

        [StringLength(1000)]
        public string DescriptionEn { get; set; }

        public string ContentEn { get; set; }

        [StringLength(200)]
        public string TagEn { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [StringLength(200)]
        public string OtherPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? SavePrice { get; set; }

        public short? Discount { get; set; }

        public int? CategoryID { get; set; }

        public int? ManufacturerID { get; set; }

        public int? OriginID { get; set; }

        public bool? InStock { get; set; }

        public int? Views { get; set; }

        public double? Rating { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? IsHot { get; set; }

        public bool? IsNew { get; set; }

        public bool? IsBestSeller { get; set; }

        public bool? IsSaleOff { get; set; }

        public bool? IsShowOnHomePage { get; set; }

        public int? Priority { get; set; }

        public bool? IsAvailable { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual Origin Origin { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductDownload> ProductDownloads { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductImage> ProductImages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductLength> ProductLengths { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOfSame> ProductOfSames { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOptionCategory> ProductOptionCategories { get; set; }

        public virtual Rating Rating1 { get; set; }
    }
}
