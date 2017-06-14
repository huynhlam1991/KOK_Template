using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TranLe_pj.Models;

namespace TranLe_pj.Common
{
    public class Common
    {
        List<CategoryModel> dt = new List<CategoryModel>();
        public List<CategoryModel> Tree
        {
            get { return dt; }
        }
        int level = -1;
        public void RecursiveFillTree(List<ProductCategory> dtParent, int parentID, string SeparatorCharacter)
        {
            level++; //on the each call level increment 1
            System.Text.StringBuilder appender = new System.Text.StringBuilder();

            for (int j = 0; j < level; j++)
                appender.Append(SeparatorCharacter);

            var dv = new List<ProductCategory>(dtParent);

            dv = dv.Where(m=>m.ParentID.GetValueOrDefault() == parentID).ToList();

            if (dv.Count > 0)
            {
                foreach (ProductCategory drv in dv)
                {
                    CategoryModel obj = new CategoryModel();
                    obj.ImageName = drv.ImageName;
                    obj.Level = level;
                    obj.ProductCategoryID = drv.ProductCategoryID;
                    obj.ProductCategoryName = HttpContext.Current.Server.HtmlDecode(appender.ToString() + drv.ProductCategoryName);
                    obj.ProductCategoryNameEn = drv.ProductCategoryNameEn;
                    obj.Description = drv.Description;
                    obj.DescriptionEn = drv.DescriptionEn;
                    obj.Content = drv.Content;
                    obj.ContentEn = drv.ContentEn;
                    obj.MetaTitle = drv.MetaTitle;
                    obj.MetaTitleEn = drv.MetaTitleEn;
                    obj.MetaDescription = drv.MetaDescription;
                    obj.MetaDescriptionEn = drv.MetaDescriptionEn;
                    obj.ParentID = drv.ParentID.GetValueOrDefault();
                    obj.SortOrder = drv.SortOrder.GetValueOrDefault();
                    obj.IsShowOnMenu = !drv.IsShowOnMenu.HasValue ? false : drv.IsShowOnMenu.Value;
                    obj.IsShowOnHomePage = !drv.IsShowOnHomePage.HasValue ? false : drv.IsShowOnHomePage.Value;
                    obj.IsAvailable = !drv.IsAvailable.HasValue ? false : drv.IsAvailable.Value;
                    dt.Add(obj);
                    RecursiveFillTree(dtParent, drv.ProductCategoryID, SeparatorCharacter);
                }
            }

            level--; //on the each function end level will decrement by 1
        }

    }
}