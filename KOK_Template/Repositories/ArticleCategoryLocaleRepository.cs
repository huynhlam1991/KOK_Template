using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TranLe.Models.Article;
using TranLe.ViewModels;

namespace TranLe.Repositories
{
    public class ArticleCategoryLocaleRepository
    {
        TranLe.DBContext.TranLeDBContext db = new TranLe.DBContext.TranLeDBContext();
        public ArticleCategoryLocaleViewModel ArticleCategoryLocaleSelectOne(int articleCategoryID = 0, int cultureID = 0)
        {
            IQueryable<ArticleCategoryLocaleViewModel> data;
            using (var db = new DBContext.TranLeDBContext())
            {
                data = db.ArticleCategoryLocales
                    .Where(x => x.ArticleCategoryID == articleCategoryID && x.CultureID == cultureID)
                    .Select(e => new ArticleCategoryLocaleViewModel
                    {
                        ArticleCategoryID = e.ArticleCategoryID,
                        CategoryName = e.CategoryName,
                        MetaTitle = e.MetaTitle,
                        MetaDescription = e.MetaDescription,
                        Description = e.Description,
                        Content = e.Content,
                    });

                return data.FirstOrDefault();
            }
        }

        public void CreateArticleCategoryLocale(ArticleCategoryLocaleViewModel model)
        {
            var acl = new ArticleCategoryLocale();
            acl.ArticleCategoryID = model.ArticleCategoryID;
            acl.CultureID = model.CultureID;
            acl.MetaTitle = model.MetaTitle;
            acl.MetaDescription = model.MetaDescription;
            acl.CategoryName = model.CategoryName;
            acl.Description = model.Description;
            acl.Content = model.Content;
            db.ArticleCategoryLocales.Add(acl);
            db.SaveChanges();
        }

        public void UpdateArticleCategoryLocale(ArticleCategoryLocaleViewModel model)
        {
            var data = db.ArticleCategoryLocales.SingleOrDefault(x => x.ArticleCategoryID == model.ArticleCategoryID && x.CultureID == model.CultureID);
            if (data != null)
            {
                data.MetaTitle = model.MetaTitle;
                data.MetaDescription = model.MetaDescription;
                data.CategoryName = model.CategoryName;
                data.Description = model.Description;
                data.Content = model.Content;
                db.SaveChanges();
            }
        }
    }
}