using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TranLe.DBContext;
using TranLe.Models.Article;
using TranLe.ViewModels;

namespace TranLe.Repositories
{
    public class ArticleLocaleRepository
    {
        TranLeDBContext db = new TranLeDBContext();
        public ArticleLocaleViewModel ArticleLocaleSelectOne(int articleID = 0, int cultureID = 0)
        {
            IQueryable<ArticleLocaleViewModel> data;
            using (var db = new DBContext.TranLeDBContext())
            {
                data = db.ArticleLocales
                    .Where(x => x.ArticleID == articleID && x.CultureID == cultureID)
                    .Select(e => new ArticleLocaleViewModel
                    {
                        ArticleID = e.ArticleID,
                        Title = e.Title,
                        Tag = e.Tag,
                        MetaTitle = e.MetaTitle,
                        MetaDescription = e.MetaDescription,
                        Description = e.Description,
                        Content = e.Content,
                    });

                return data.FirstOrDefault();
            }
        }

        public void CreateArticleLocale(ArticleLocaleViewModel model)
        {
            var al = new ArticleLocale();
            al.ArticleID = model.ArticleID;
            al.CultureID = model.CultureID;
            al.MetaTitle = model.MetaTitle;
            al.MetaDescription = model.MetaDescription;
            al.Tag = model.Tag;
            al.Title = model.Title;
            al.Description = model.Description;
            al.Content = model.Content;
            db.ArticleLocales.Add(al);
            db.SaveChanges();
        }

        public void UpdateArticleLocale(ArticleLocaleViewModel model)
        {
            var data = db.ArticleLocales.SingleOrDefault(x => x.ArticleID == model.ArticleID && x.CultureID == model.CultureID);
            if (data != null)
            {
                data.MetaTitle = model.MetaTitle;
                data.MetaDescription = model.MetaDescription;
                data.Tag = model.Tag;
                data.Title = model.Title;
                data.Description = model.Description;
                data.Content = model.Content;
                db.SaveChanges();
            }
        }
    }
}