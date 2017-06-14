using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranLe_pj.Models;
using TranLe_pj.Areas.admin.GetData;
using System.Configuration;

namespace TranLe_pj.Controllers
{
    public class ContactController : Controller
    {
        private Post _post = new Post();
        // GET: Contact
        [Route("lien-he.html")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMail(FormCollection form)
        {
            string txtName = form["txtName"].Trim();
            string txtAddress = form["txtAddress"].Trim();
            string txtPhone = form["txtPhone"].Trim();
            string txtEmail = form["txtEmail"].Trim();
            string Content = form["Content"].Trim();

            string Body = "<div style='width: 100%; font-size: 11px; font-family: Arial;'>";
            Body += "<h3 style='color: rgb(204,102,0); font-size: 22px; border-bottom-color: gray; border-bottom-width: 1px;border-bottom-style: dashed; margin-bottom: 20px; font-family: Times New Roman;'>";
            Body += "Phản hồi của khách hàng: <b>"+txtName+"</b>";
            Body += "</h3>";
            Body += "<div style='font-family: Bookstore; font-size: 11px; margin-bottom: 20px;'>";
            Body += "<div style='padding: 10px; background-color: rgb(255,244,234); font-family: Verdana;font-size: 11px; margin-bottom: 20px;'>";
            Body += "<p>Thông tin chi tiết xem bên dưới:</p>";
            Body += "</div>";
            Body += "<p><b>Người gửi</b></p>";
            Body += "<p>Họ và tên: " + txtName + "</p>";
            Body += "<p>Email: " + txtEmail + "</p>";
            Body += "<p>Điện thoại: " + txtPhone + "</p>";
            Body += "<p>Địa chỉ: " + txtAddress + "</p>";
            Body += "<p>Nội dung: <i>" + Content + "</i></p>";
            Body += "</div>";
            var fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = Server.MapPath("~/config/app.config") };
            var config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            var section = (AppSettingsSection)config.GetSection("appSettings");
            var strUseSSL = section.Settings["UseSSL"].Value;

            string EmailNhan = section.Settings["ReceivedEmails"].Value;
            TLLib.Common.SendMail("smtp.dacsancuchi.com", 587, "lienhe@dacsancuchi.com", "nmm3A3@1", EmailNhan, "", "Mai Trung - Phản hồi của khách hàng: " + txtName, Body, true);
            return RedirectToAction("Index");
        }
    }
}