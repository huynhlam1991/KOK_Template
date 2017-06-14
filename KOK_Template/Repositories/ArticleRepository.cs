using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using TranLe.DBContext;
using TranLe.Models.Article;
using TranLe.ViewModels;

namespace TranLe.Repositories
{
    public class ArticleRepository
    {
        TranLeDBContext db = new TranLeDBContext();
        public IEnumerable<ArticleViewModel> getAllArticle(int startRow = 0, int endRow = 50)
        {
            IQueryable<ArticleViewModel> data;
            using (var db = new DBContext.TranLeDBContext())
            {
                data = db.Articles
                    .Include("ArticleCategories.ArticleCategoryLocales")
                    .Where(x => x.IsDeleted == false)
                    .Select(e => new ArticleViewModel
                    {
                        ArticleID = e.ArticleID,
                        ArticleCategoryID = e.ArticleCategoryID,
                        ImageName = e.ImageName == null ? "" : e.ImageName,
                        IsHot = e.IsHot,
                        IsNew = e.IsNew,
                        Priority = e.Priority,
                        IsShowOnHomePage = e.IsShowOnHomePage,
                        IsAvailable = e.IsAvailable,
                        CreateDate = e.CreateDate,
                        UpdatedDate = e.UpdatedDate,
                        CategoryName = e.ArticleCategory.ArticleCategoryLocales.FirstOrDefault().CategoryName,
                        Title = e.ArticleLocales.FirstOrDefault().Title
                    });

                return data.OrderByDescending(x => x.CreateDate).Skip(startRow).Take(endRow).ToList();
            }
        }
        public ArticleViewModel ArticleSelectOne(int articleID = 0)
        {
            IQueryable<ArticleViewModel> data;
            using (var db = new DBContext.TranLeDBContext())
            {
                data = db.Articles
                    .Where(x => x.ArticleID == articleID)
                    .Select(e => new ArticleViewModel
                    {
                        ArticleID = e.ArticleID,
                        ArticleCategoryID = e.ArticleCategoryID,
                        ImageName = e.ImageName,
                        IsAvailable = e.IsAvailable,
                        IsHot = e.IsHot,
                        IsNew = e.IsNew,
                        IsShowOnHomePage = e.IsShowOnHomePage,
                        CreateDate = e.CreateDate,
                        UpdatedDate = e.UpdatedDate,
                        CategoryName = e.ArticleCategory.ArticleCategoryLocales.FirstOrDefault().CategoryName,
                        Title = e.ArticleLocales.FirstOrDefault().Title
                    });

                return data.FirstOrDefault();
            }
        }
        public int CreateArticle(Article model)
        {
            db.Articles.Add(model);
            db.SaveChanges();
            return model.ArticleID;
        }
        public void UpdateArticle(Article model)
        {
            var data = db.Articles.SingleOrDefault(x => x.ArticleID == model.ArticleID);
            if (data != null)
            {
                data.ArticleCategoryID = model.ArticleCategoryID;
                data.ImageName = model.ImageName;
                data.IsAvailable = model.IsAvailable;
                data.IsHot = model.IsHot;
                data.IsNew = model.IsNew;
                data.IsShowOnHomePage = model.IsShowOnHomePage;
                data.Priority = model.Priority;
                db.SaveChanges();
            }
        }

        public void UpdateArticleImage(int articleID, string Image)
        {
            var data = db.Articles.SingleOrDefault(x => x.ArticleID == articleID);
            if (data != null)
            {
                data.ImageName = Image;
                db.SaveChanges();
            }
        }

        public void UpdateArticleQuickUpdate(ArticleViewModel model)
        {
            var data = db.Articles.SingleOrDefault(x => x.ArticleID == model.ArticleID);
            if (data != null)
            {
                data.IsAvailable = model.IsAvailable;
                data.IsHot = model.IsHot;
                data.IsNew = model.IsNew;
                data.IsShowOnHomePage = model.IsShowOnHomePage;
                data.Priority = model.Priority;
                db.SaveChanges();
            }
        }
        public void DeleteArticle(int articleID)
        {
            var data = db.Articles.SingleOrDefault(x => x.ArticleID == articleID);
            if (data != null)
            {
                try
                {
                    data.Delete();
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    string errors = string.Empty;
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        string abc = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);

                        foreach (var ve in eve.ValidationErrors)
                        {
                            string abc1 = string.Format("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                            errors += abc1 + "\n";
                        }
                    }
                    throw new Exception(errors);
                }
            }
        }
        //public IEnumerable<ArticleLocaleViewModel> getAllArticleLocale(int startRow = 0, int endRow = 50)
        //{
        //    IQueryable<ArticleLocaleViewModel> data;
        //    using (var db = new DBContext.TranLeDBContext())
        //    {
        //        data = db.ArticleLocales
        //            .Include("Articles.ArticleCategories.ArticleCategoryLocales")
        //            .Select(e => new ArticleLocaleViewModel
        //            {
        //                ArticleID = e.ArticleID,
        //                Title = e.Title,
        //                Tag = e.Tag,
        //                MetaTitle = e.MetaTitle,
        //                MetaDescription = e.MetaDescription,
        //                Description = e.Description,
        //                Content = e.Content,
        //                CategoryName = e.Article.ArticleCategory.ArticleCategoryLocales.FirstOrDefault().CategoryName
        //            });

        //        return data.OrderBy(x => x.CreateDate).Skip(startRow).Take(endRow).ToList();
        //    }
        //}
    }
}