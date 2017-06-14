namespace KOK_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int MenuID { get; set; }

        [StringLength(100)]
        public string ImageName { get; set; }

        [StringLength(100)]
        public string ImageNameEn { get; set; }

        [StringLength(100)]
        public string MenuTitle { get; set; }

        [StringLength(100)]
        public string MenuTitleEn { get; set; }

        [StringLength(500)]
        public string Link { get; set; }

        [StringLength(500)]
        public string LinkEn { get; set; }

        public int? MenuPositionID { get; set; }

        public int? ParentID { get; set; }

        public byte? SortOrder { get; set; }

        public bool? IsAvailable { get; set; }

        public virtual MenuPosition MenuPosition { get; set; }
    }
}
