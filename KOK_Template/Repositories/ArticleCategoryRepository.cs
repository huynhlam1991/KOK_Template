using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Web;
using TranLe.Models.Article;
using TranLe.ViewModels;

namespace TranLe.Repositories
{
    public class ArticleCategoryRepository
    {
        TranLe.DBContext.TranLeDBContext db = new TranLe.DBContext.TranLeDBContext();

        public IEnumerable<ArticleCategoryViewModel> getAllArticleCategory()
        {
            IQueryable<ArticleCategoryViewModel> data;
            using (var db = new DBContext.TranLeDBContext())
            {
                data = db.ArticleCategories
                    .Include("ArticleCategoryLocales")
                    .Where(x => x.IsDeleted == false)
                    .Select(e => new ArticleCategoryViewModel
                    {
                        ArticleCategoryID = e.ArticleCategoryID,
                        ImageName = e.ImageName == null ? "" : e.ImageName,
                        IsShowOnMenu = e.IsShowOnMenu,
                        IsShowOnHomePage = e.IsShowOnHomePage,
                        IsAvailable = e.IsAvailable,
                        CreateDate = e.CreateDate,
                        UpdatedDate = e.UpdatedDate,
                        CategoryName = e.ArticleCategoryLocales.FirstOrDefault().CategoryName
                    });

                return data.OrderBy(x => x.CreateDate).ToList();
            }
        }
        public DataTable getAllArticleCategory(int parentID, int increaseLevelCount, bool? showonhomepage, bool? showonmenu)
        {
            db.Configuration.LazyLoadingEnabled = false;
            var data = db.ArticleCategories
                .Where(x => x.IsDeleted == false)
                .Select(e => new ArticleCategoryViewModel {
                ArticleCategoryID = e.ArticleCategoryID,
                CategoryName = e.ArticleCategoryLocales.FirstOrDefault().CategoryName,
                ParentCategoryName = db.ArticleCategoryLocales.Where(y => y.ArticleCategoryID == (e.ParentID.HasValue ? e.ParentID.Value : 0)).FirstOrDefault().CategoryName,
                ImageName = e.ImageName,
                ParentID = string.IsNullOrEmpty(e.ParentID.ToString()) ? 0 : e.ParentID,
                SortOrder = e.SortOrder,
                IsShowOnMenu = e.IsShowOnMenu,
                IsShowOnHomePage = e.IsShowOnHomePage,
                IsAvailable = e.IsAvailable,
                CreateDate = e.CreateDate,
                UpdatedDate = e.UpdatedDate,
                IsDeleted = e.IsDeleted
            }).OrderBy(x => x.ParentID).ThenBy(x => x.SortOrder).ToList();

            TLLib.Common oCommon = new TLLib.Common();
            oCommon.RecursiveFillTree1(ToDataTable(data.ToList()), parentID, "ParentID", "CategoryName", "ArticleCategoryID", increaseLevelCount, showonmenu.ToString(), showonhomepage.ToString(), "-");
            return oCommon.Tree;
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        private IEnumerable<ArticleCategoryViewModel> ConvertToTankReadings(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                yield return new ArticleCategoryViewModel
                {
                    ArticleCategoryID = Convert.ToInt32(row["ArticleCategoryID"]),
                    ImageName = row["ImageName"].ToString(),
                    CategoryName = row["CategoryName"].ToString(),
                    ParentCategoryName = row["CategoryName"].ToString(),                    
                    ParentID = string.IsNullOrEmpty(row["ParentID"].ToString()) ? 0 : Convert.ToInt32(row["ParentID"]),
                    SortOrder = string.IsNullOrEmpty(row["SortOrder"].ToString()) ? 0 : Convert.ToInt32(row["SortOrder"]),
                    IsShowOnMenu = Convert.ToBoolean(row["IsShowOnMenu"]),
                    IsShowOnHomePage = Convert.ToBoolean(row["IsShowOnHomePage"]),
                    IsAvailable = Convert.ToBoolean(row["IsAvailable"]),
                    CreateDate = Convert.ToDateTime(row["CreateDate"]),
                    UpdatedDate = Convert.ToDateTime(row["UpdatedDate"])
                };
            }

        }

        public ArticleCategoryViewModel ArticleCategorySelectOne(int articleCategoryID = 0)
        {
            IQueryable<ArticleCategoryViewModel> data;
            using (var db = new DBContext.TranLeDBContext())
            {
                data = db.ArticleCategories
                    .Where(x => x.ArticleCategoryID == articleCategoryID)
                    .Select(e => new ArticleCategoryViewModel
                    {
                        ArticleCategoryID = e.ArticleCategoryID,
                        ImageName = e.ImageName,
                        ParentID = e.ParentID,
                        SortOrder = e.SortOrder,
                        IsShowOnMenu = e.IsShowOnMenu,
                        IsShowOnHomePage = e.IsShowOnHomePage,
                        IsAvailable = e.IsAvailable,
                        CreateDate = e.CreateDate,
                        UpdatedDate = e.UpdatedDate,
                        CategoryName = e.ArticleCategoryLocales.FirstOrDefault().CategoryName
                    });

                return data.FirstOrDefault();
            }
        }

        public int CreateArticleCategory(ArticleCategory model)
        {
            try
            {
                db.ArticleCategories.Add(model);
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
            return model.ArticleCategoryID;
        }
        public void UpdateArticleCategory(ArticleCategory model)
        {
            var data = db.ArticleCategories.SingleOrDefault(x => x.ArticleCategoryID == model.ArticleCategoryID);
            if (data != null)
            {
                data.ArticleCategoryID = model.ArticleCategoryID;
                data.ImageName = model.ImageName;
                data.ParentID = model.ParentID;
                data.SortOrder = model.SortOrder;
                data.IsShowOnMenu = model.IsShowOnMenu;                
                data.IsShowOnHomePage = model.IsShowOnHomePage;
                data.IsAvailable = model.IsAvailable;
                db.SaveChanges();
            }
        }

        public void UpdateArticleCategoryImage(int articleCategoryID, string Image)
        {
            var data = db.ArticleCategories.SingleOrDefault(x => x.ArticleCategoryID == articleCategoryID);
            if (data != null)
            {
                data.ImageName = Image;
                db.SaveChanges();
            }
        }

        public void UpdateArticleCategoryQuickUpdate(ArticleCategoryViewModel model)
        {
            var data = db.ArticleCategories.SingleOrDefault(x => x.ArticleCategoryID == model.ArticleCategoryID);
            if (data != null)
            {
                data.IsAvailable = model.IsAvailable;
                data.IsShowOnMenu = model.IsShowOnMenu;
                data.IsShowOnHomePage = model.IsShowOnHomePage;
                db.SaveChanges();
            }
        }
        public void DeleteArticleCategory(int articleCategoryID)
        {
            var data = db.ArticleCategories.SingleOrDefault(x => x.ArticleCategoryID == articleCategoryID);
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

        public DataTable getAllArticleCategoryForEdit(int articlecategoryID)
        {
            db.Configuration.LazyLoadingEnabled = false;
            var data = db.ArticleCategories
                .Where(x => x.IsDeleted == false && x.ArticleCategoryID != articlecategoryID)
                .Select(e => new ArticleCategoryViewModel
                {
                    ArticleCategoryID = e.ArticleCategoryID,
                    CategoryName = e.ArticleCategoryLocales.FirstOrDefault().CategoryName,
                    ParentID = e.ParentID.HasValue ? e.ParentID : 0,
                    ParentCategoryName = db.ArticleCategoryLocales.Where(y => y.ArticleCategoryID == (e.ParentID.HasValue ? e.ParentID.Value : 0)).FirstOrDefault().CategoryName,
                    SortOrder = e.SortOrder,
                    IsAvailable = e.IsAvailable
                }).OrderBy(x => x.SortOrder).ToList();

            TLLib.Common oCommon = new TLLib.Common();
            oCommon.RecursiveFillTree(ToDataTable(data.ToList()), 0, "ParentID", "CategoryName", "ArticleCategoryID", "-");
            return oCommon.Tree;
        }

        public void ArticleCategoryUpOrder(int articlecategoryID)
        {
            var a = db.ArticleCategories.Where(x => x.ArticleCategoryID == articlecategoryID).FirstOrDefault().ParentID;
            string strParentID = a != null ? a.Value.ToString() : "";
            var b = db.ArticleCategories.Where(x => x.ArticleCategoryID == articlecategoryID).FirstOrDefault().SortOrder;
            int iCurrentSortOrder = b != null ? b.Value : 0;
            int iPrevSortOrder = 0, iPrevProductCategoryID = 0;
            int? nullableInt = null;

            if (!string.IsNullOrEmpty(strParentID))
            {
                int iParentID = Convert.ToInt32(strParentID);
                iPrevSortOrder = db.ArticleCategories.Where(x => x.SortOrder < iCurrentSortOrder && x.ParentID == iParentID).Max(x => x.SortOrder).Value;
                iPrevProductCategoryID = db.ArticleCategories.Where(x => x.SortOrder == iPrevSortOrder && x.ParentID == iParentID).FirstOrDefault().ArticleCategoryID;
            }
            else
            {
                var c = db.ArticleCategories.Where(x => x.SortOrder < iCurrentSortOrder && x.ParentID == nullableInt).Max(x => x.SortOrder);
                iPrevSortOrder = c != null ? c.Value : 0;
                iPrevProductCategoryID = db.ArticleCategories.Where(x => x.SortOrder == iPrevSortOrder && x.ParentID == nullableInt).FirstOrDefault().ArticleCategoryID;
            }

            if(iCurrentSortOrder != 1)
            {
                iCurrentSortOrder = iCurrentSortOrder - 1;
            }

            iPrevSortOrder = iPrevSortOrder + 1;

            var data = db.ArticleCategories.SingleOrDefault(x => x.ArticleCategoryID == articlecategoryID);
            if (data != null)
            {
                data.SortOrder = Convert.ToByte(iCurrentSortOrder);
                db.SaveChanges();
            }

            var data2 = db.ArticleCategories.SingleOrDefault(x => x.ArticleCategoryID == iPrevProductCategoryID);
            if (data2 != null)
            {
                data2.SortOrder = Convert.ToByte(iPrevSortOrder);
                db.SaveChanges();
            }
        }

        public void ArticleCategoryDownOrder(int articlecategoryID)
        {
            string strParentID = db.ArticleCategories.Where(x => x.ArticleCategoryID == articlecategoryID).FirstOrDefault().ParentID.Value.ToString();
            int iCurrentSortOrder = db.ArticleCategories.Where(x => x.ArticleCategoryID == articlecategoryID).FirstOrDefault().SortOrder.Value;
            int iMaxSortOrder = 0, iNextSortOrder = 0, iNextProductCategoryID = 0;
            int? nullableInt = null;

            if (!string.IsNullOrEmpty(strParentID))
            {
                int iParentID = Convert.ToInt32(strParentID);
                iMaxSortOrder = db.ArticleCategories.Where(x => x.ParentID == iParentID).Count();
                iNextSortOrder = db.ArticleCategories.Where(x => x.SortOrder > iCurrentSortOrder && x.ParentID == iParentID).Min(x => x.SortOrder).Value;
                iNextProductCategoryID = db.ArticleCategories.Where(x => x.SortOrder == iNextSortOrder && x.ParentID == iParentID).FirstOrDefault().ArticleCategoryID;
            }
            else
            {
                iMaxSortOrder = db.ArticleCategories.Where(x => x.ParentID == nullableInt).Count();
                iNextSortOrder = db.ArticleCategories.Where(x => x.SortOrder > iCurrentSortOrder && x.ParentID == nullableInt).Min(x => x.SortOrder).Value;
                iNextProductCategoryID = db.ArticleCategories.Where(x => x.SortOrder == iNextSortOrder && x.ParentID == nullableInt).FirstOrDefault().ArticleCategoryID;
            }

            if (iCurrentSortOrder != iMaxSortOrder)
            {
                iCurrentSortOrder = iCurrentSortOrder + 1;
            }

            iNextSortOrder = iNextSortOrder - 1;

            var data = db.ArticleCategories.SingleOrDefault(x => x.ArticleCategoryID == articlecategoryID);
            if (data != null)
            {
                data.SortOrder = Convert.ToByte(iCurrentSortOrder);
                db.SaveChanges();
            }

            var data2 = db.ArticleCategories.SingleOrDefault(x => x.ArticleCategoryID == iNextProductCategoryID);
            if (data2 != null)
            {
                data2.SortOrder = Convert.ToByte(iNextSortOrder);
                db.SaveChanges();
            }
        }
    }
}