using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TranLe_pj.Models
{
    public class PostModel
    {
        public int ProductID { get; set; }
        public string ImageName { get; set; }
        public string MetaTittle { get; set; }
        public string MetaDescription { get; set; }
        public string ProductName { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public string Tag { get; set; }
        public string MetaTittleEn { get; set; }
        public string MetaDescriptionEn { get; set; }
        public string ProductNameEn { get; set; }
        [AllowHtml]
        public string DescriptionEn { get; set; }
        [AllowHtml]
        public string ContentEn { get; set; }
        public string TagEn { get; set; }
        public decimal? Price { get; set; }
        public string OtherPrice { get; set; }
        public decimal? SavePrice { get; set; }
        public short? Discount { get; set; }
        public int? CategoryID { get; set; }
        public int? ManufacturerID { get; set; }
        public int? OriginID { get; set; }
        public bool? InStock { get; set; }
        public int? Views { get; set; }
        public double? Rating { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool IsHot { get; set; }
        public bool IsNew { get; set; }
        public bool? IsBestSeller { get; set; }
        public bool? IsSaleOff { get; set; }
        public bool IsShowOnHomePage { get; set; }
        public int? Priority { get; set; }
        public bool IsAvailable { get; set; }
        public List<ListItem> listItem;
        public List<ListItem> listOrigin;

    }
    public class ListItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
    public class PostCategory
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

    }
    public class PostImage
    {
        public int ProductImageID { get; set; }
        public string ImageName { get; set; }
        public string Title { get; set; }
        public string Descripttion { get; set; }
        public string TitleEn { get; set; }
        public string DescripttionEn { get; set; }
        public int ProductID { get; set; }
        public bool IsAvailable { get; set; }
        public int Priority { get; set; }

    }
    public class TemplateHTML
    {
        public string title { get; set; }
        public string description { get; set; }
        public string content { get; set; }
    }

}