namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdsCategory")]
    public partial class AdsCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdsCategory()
        {
            AdsBanners = new HashSet<AdsBanner>();
        }

        public int AdsCategoryID { get; set; }

        [StringLength(100)]
        public string AdsCategoryName { get; set; }

        public bool? IsAvailable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdsBanner> AdsBanners { get; set; }
    }
}
