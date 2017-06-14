using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranLe_pj.Models;
using TranLe_pj.Areas.admin.GetData;

namespace TranLe_pj.Controllers
{
    public class EventsController : Controller
    {
        private Post _post = new Post();
        // GET: Products
        [Route("event.html")]
        public ActionResult Index(int? id, int? page)
        {
            int cateID = id.HasValue ? id.Value : 11;
            
            var model = _post.getAllByCate(cateID).Where(m=>m.IsAvailable==true).ToList();
            ViewBag.CateID = cateID;
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