using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DayUp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        [HttpPost]
        public ActionResult GetBannerData()
        {

            return Json(Dal.ContentSearch.GetBannerData(),JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetRankingData()
        {
            return Json(Dal.ContentSearch.GetRankingData(),JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetSubContent()
        {
            return Json(Dal.ContentSearch.GetSubContent(),JsonRequestBehavior.AllowGet);
        }
        public ActionResult MatchSponsors()
        {
            return Json(Dal.MatchSponsors.MatchSponsorsLogos(),JsonRequestBehavior.AllowGet);
        }
    }
}