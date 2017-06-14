using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranLe_pj.Models;
using TranLe_pj.Areas.admin.GetData;

namespace TranLe_pj.Controllers
{
    public class ProductsController : Controller
    {
        private Post _post = new Post();
        // GET: Products
        public ActionResult Index(int? id, int? page, int? origin)
        {
            int cateID = id.HasValue ? id.Value : 1;
            var model = _post.getAllByCate(cateID).Where(m=>m.IsAvailable == true).OrderByDescending(m=>m.CreateDate).ToList();
            if (origin.HasValue && origin.Value != 0)
            {
                model = model.Where(m => m.OriginID == origin.Value).ToList();
            }
            ViewBag.CateID = cateID;
            ViewBag.OriginID = origin.GetValueOrDefault();
            ViewBag.PageCurrent = page.HasValue ? page.Value : 1;
            
            return View(model);
        }
        public ActionResult Detail(int id)
        {
            var model = _post.getProductByID(id);
            
            return View(model);
        }
    }
}