using DayUp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DayUp.Controllers
{
    public class HomeController : Controller
    {
        private DayUpEntities1 db = new DayUpEntities1();
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

            return Json(Dal.ContentSearch.GetBannerData(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获前10排名数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetRankingData()
        {
            return Json(Dal.ContentSearch.GetRankingData(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        ///  获得用于填充普通内容的数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetSubContent()
        {
            return Json(Dal.ContentSearch.GetSubContent(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获得展示赞助商的数据
        /// </summary>
        /// <returns></returns>
        public ActionResult MatchSponsors()
        {
            return Json(Dal.MatchSponsors.MatchSponsorsLogos(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 返回对于搜索框中包含关键字的数据
        /// </summary>
        /// <param name="keyword">搜索框中string类型的关键字</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GoSearch(string keyword)
        {
            return Json(Dal.ContentSearch.GoSearch(keyword), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MatchUser(string username, string userpassword)
        {
            if (Dal.UserInfo.MatchUser(username, userpassword) != null)
            {
                var data = Dal.UserInfo.MatchUser(username, userpassword);
                int id = data.id;
                Session["userID"] = id;
                return Json(Dal.UserInfo.MatchUser(username, userpassword), JsonRequestBehavior.AllowGet);
            }
            return Json(1, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// 展示用户个人收藏内容列表
        /// </summary>
        /// <returns></returns>
        public ActionResult CollectionList()
        {
            if (Session["userID"] != null)
            {
                return View();
            }
            else
            {

                return Content("请您登录后查看！");
            }

        }

        /// <summary>
        /// 获取用户个人内容收藏列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ActionResult GetYourList(string ids)
        {
            //int id = Convert.ToInt16(Session["userID"].ToString());
            if (Session["userID"] != null)
            {
                int id = Convert.ToInt16(Session["userID"].ToString());
                return Json(Dal.MatchCollectionList.MatchYourList(id), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Content("请您登录后查看！");
            }

        }

        /// <summary>
        /// 删除用户的个人内容收藏
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DelLike(string user_id, int id)
        {
            DayUpEntities1 db = new DayUpEntities1();
            //CollectionInfo ci = new CollectionInfo();
            //int userid = Convert.ToInt16(user_id);
            var dat = (from con in db.CollectionInfo
                       where con.id == id
                       select con).FirstOrDefault();
            if (dat != null)
            {
                db.CollectionInfo.Remove(dat);
                db.SaveChanges();
                return Content("OK");
            }
            return Content("False");
        }

        /// <summary>
        /// 管理员页面
        /// </summary>
        /// <returns></returns>

        public ActionResult Manager()
        {
            return View();
        }

        /// <summary>
        /// 获取 LoginPartial 中显示的用户名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetUserName(int id)
        {
            DayUpEntities1 db = new DayUpEntities1();
            var name = (from na in db.UserInfo
                        where na.id == id
                        select na.username).FirstOrDefault();
            return Content(name);
        }
        public ActionResult ShowComment()
        {
            return View();
        }

        public ActionResult YourComment()
        {
           // int id = Convert.ToInt16(Session["userID"].ToString());
            if (Session["userID"] != null)
            {
                int id = Convert.ToInt16(Session["userID"].ToString());
                return View(Dal.Testin.MatchYourComment(id));
            }
            else
            {
                return Content("请您登录后查看");
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommenInfo commenInfo = db.CommenInfo.Find(id);
            if (commenInfo == null)
            {
                return HttpNotFound();
            }
            // return Action ;
            return View(commenInfo);
        }

        // POST: CommenInfoes/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,userid,contentid,url,title,commen")] CommenInfo commenInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commenInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("YourComment");
            }
            return View(commenInfo);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommenInfo commenInfo = db.CommenInfo.Find(id);
            if (commenInfo == null)
            {
                return HttpNotFound();
            }
            return View(commenInfo);
        }

        // POST: CommenInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommenInfo commenInfo = db.CommenInfo.Find(id);
            db.CommenInfo.Remove(commenInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}