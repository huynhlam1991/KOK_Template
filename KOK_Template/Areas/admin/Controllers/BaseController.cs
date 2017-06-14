using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KOK_Template.Areas.admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //check Session here
            if (Session["UserId"] == null || Session["UserName"] == null)
            {
                filterContext.Result = RedirectToAction("Index", "Login");
            }
        }
    }
}