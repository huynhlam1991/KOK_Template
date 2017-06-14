using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Web;

namespace KOK_Template.Models
{
    public class BaseEntityCategory
    {
        public BaseEntityCategory()
        {
            CreateDate = DateTime.Now;
            //CreatedBy = Thread.CurrentPrincipal.Identity.Name;
            UpdatedBy = CreatedBy = "admin";
        }

        [StringLength(100)]
        public string ImageName { get; set; }

        public int? ParentID { get; set; }

        public byte? SortOrder { get; set; }

        public bool? IsShowOnMenu { get; set; }

        public bool? IsShowOnHomePage { get; set; }

        public bool? IsAvailable { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày tạo")]
        [ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày cập nhật")]
        [ScaffoldColumn(false)]
        public DateTime? UpdatedDate { get; set; }

        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public string UpdatedBy { get; set; }

        public string Note { get; set; }

        protected void UpdateMetadata()
        {
            UpdatedDate = DateTime.Now;
            //UpdatedBy = Thread.CurrentPrincipal.Identity.Name;
            UpdatedBy = "admin";
        }

        public virtual void Delete()
        {
            IsDeleted = true;
            UpdateMetadata();
        }
    }
}