using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KOK_Template.Models
{
    public class BaseEntityContent
    {
        [StringLength(500)]
        public string MetaTitle { get; set; }

        [StringLength(1000)]
        public string MetaDescription { get; set; }

        [StringLength(200)]
        public string Tag { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public string Content { get; set; }
    }
}