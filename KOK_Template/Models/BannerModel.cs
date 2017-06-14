using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TranLe_pj.Models
{
    public class AdsBannerModel
    {
        public int AdsBannerID { get; set; }
        public string FileName { get; set; }
        public int? AdsCategoryID { get; set; }
        public string AdsCategoryName { get; set; }
        public string CompanyName { get; set; }
        public string Website { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? Priority { get; set; }
        public bool IsAvailable { get; set; }
        public double? Ratio { get; set; }
    }
    public class AdsCategoryModel
    {
        public int AdsCategoryID { get; set; }
        public string AdsCategoryName { get; set; }
        public bool IsAvailable { get; set; }
    }
}