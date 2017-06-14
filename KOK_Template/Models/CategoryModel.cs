using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TranLe_pj.Models
{
    public class CategoryModel
    {
        public int ProductCategoryID { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductCategoryNameEn { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public string Content { get; set; }
        public string ContentEn { get; set; }
        public string MetaTitle { get; set; }
        public string MetaTitleEn { get; set; }
        public string MetaDescription { get; set; }
        public string MetaDescriptionEn { get; set; }
        public string ImageName { get; set; }
        public int ParentID { get; set; }
        public int SortOrder { get; set; }
        public bool IsShowOnMenu { get; set; }
        public bool IsShowOnHomePage { get; set; }
        public bool IsAvailable { get; set; }
        public int Level { get; set; }
    }
}