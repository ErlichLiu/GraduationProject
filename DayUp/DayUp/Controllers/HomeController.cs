using DayUp.Models;
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
        
        /// <summary>
        /// 获得 Banner 的数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetBannerData()
        {

            return Json(Dal.ContentSearch.GetBannerData(),JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获前10排名数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetRankingData()
        {
            return Json(Dal.ContentSearch.GetRankingData(),JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        ///  获得用于填充普通内容的数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetSubContent()
        {
            return Json(Dal.ContentSearch.GetSubContent(),JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获得展示赞助商的数据
        /// </summary>
        /// <returns></returns>
        public ActionResult MatchSponsors()
        {
            return Json(Dal.MatchSponsors.MatchSponsorsLogos(),JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 返回对于搜索框中包含关键字的数据
        /// </summary>
        /// <param name="keyword">搜索框中string类型的关键字</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GoSearch(string keyword)
        {
            return Json(Dal.ContentSearch.GoSearch(keyword),JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MatchUser(string username,string userpassword)
        {
            return Json(Dal.UserInfo.MatchUser(username,userpassword),JsonRequestBehavior.AllowGet);
        }

        public ActionResult CollectionList()
        {
            return View();
        }

        public ActionResult GetYourList(string ids)
        {
            int id = Convert.ToInt16(ids);
            return Json(Dal.MatchCollectionList.MatchYourList(id),JsonRequestBehavior.AllowGet);
        }

        public ActionResult DelLike(string user_id,int id)
        {
            DayUpEntities1 db = new DayUpEntities1();
            //CollectionInfo ci = new CollectionInfo();
            int userid = Convert.ToInt16(user_id);
            var dat = (from con in db.CollectionInfo
                       where con.id==id
                       select con).FirstOrDefault();
            if(dat != null)
            {
               db.CollectionInfo.Remove(dat);
                db.SaveChanges();
                return Content("OK");
            }
            return Content("False");
        }
        public ActionResult Manager()
        {
            return View();
        }
    }
}