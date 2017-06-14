using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranLe_pj.Models;
using TranLe_pj.Areas.admin.GetData;

namespace TranLe_pj.Controllers
{
    public class HomeController : Controller
    {
        private Post _post = new Post();
        public ActionResult Index()
        {
            var model = _post.getAllProductCate().Where(m=>m.IsAvailable == true).ToList();
            ViewBag.ProductCateID = 1;
            ViewBag.NewsCateID = 11;
            
            return View(model);
        }
        public ActionResult Search(string SearchString)
        {
            ViewBag.SearchString = SearchString;
            ViewBag.Title = "Search";
            
            return View();
        }
    }
}
