using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TLLib;
using KOK_Template.Models;

namespace KOK_Template.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(UserAccountModel model)
        {
            if (ModelState.IsValid)
            {
                var encryptPass = MD5Hash.Encrypt(model.PassWord, true);
                var fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = Server.MapPath("~/config/app.config") };
                var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                var section = (AppSettingsSection)config.GetSection("appSettings");

                string UserID = section.Settings["AccountUserID"].Value;
                string UserName = section.Settings["AccountUserName"].Value;
                string PassWord = section.Settings["AccountPassword"].Value;
                Session.Timeout = 500;
                if (UserName.Equals(model.UserName) && PassWord.Equals(encryptPass))
                {
                    Session["UserId"] = UserID;
                    Session["UserName"] = model.UserName;
                    
                    return RedirectToAction("Index", "Manager");
                }
                else
                {
                    ViewBag.ErrorMsg = "Tài khoản hoặc mật khẩu không chính xác!";
                }
            }
            return View("Index");
        }
        public ActionResult SignOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}