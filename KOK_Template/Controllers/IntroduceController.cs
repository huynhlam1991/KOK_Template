using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranLe_pj.Models;
using TranLe_pj.Areas.admin.GetData;

namespace TranLe_pj.Controllers
{
    public class IntroduceController : Controller
    {
        private Post _post = new Post();
        // GET: Introduce
        [Route("gioi-thieu.html")]
        public ActionResult Index()
        {
            var model = _post.getProductByID(10);
            
            return View(model);
        }
    }
}