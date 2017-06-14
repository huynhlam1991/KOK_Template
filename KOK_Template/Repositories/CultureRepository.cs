using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TranLe.ViewModels;

namespace TranLe.Repositories
{
    public class CultureRepository
    {
        public IEnumerable<CultureViewModel> getAllCulture()
        {
            IQueryable<CultureViewModel> data;
            using (var db = new DBContext.TranLeDBContext())
            {
                data = db.Cultures
                    .Where(x => x.IsAvailable == true)
                    .Select(e => new CultureViewModel
                    {
                        CultureID = e.CultureID,
                        CultureName = e.CultureName,
                        DisplayName = e.DisplayName
                    });

                return data.ToList();
            }
        }
        public IEnumerable<CultureViewModel> getLangArticle()
        {
            IQueryable<CultureViewModel> data;
            using (var db = new DBContext.TranLeDBContext())
            {
                data = db.ArticleLocales
                    .Include("Articles")
                    .Select(e => new CultureViewModel
                    {
                        CultureID = e.CultureID,
                        CultureName = e.Culture.CultureName,
                        DisplayName = e.Culture.DisplayName
                    });

                return data.ToList();
            }
        }
    }
}