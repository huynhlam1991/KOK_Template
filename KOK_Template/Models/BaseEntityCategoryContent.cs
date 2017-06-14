using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KOK_Template.Models.KOK_Template
{
    public class BaseEntityCategoryContent
    {
        [StringLength(100)]
        public string MetaTitle { get; set; }

        [StringLength(300)]
        public string MetaDescription { get; set; }

        [StringLength(100)]
        public string CategoryName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public string Content { get; set; }
    }
}