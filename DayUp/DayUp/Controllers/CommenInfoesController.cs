using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DayUp.Models;

namespace DayUp.Controllers
{
    public class CommenInfoesController : Controller
    {
        private DayUpEntities1 db = new DayUpEntities1();

        // GET: CommenInfoes
        public ActionResult Index()
        {
            return View(db.CommenInfo.ToList());
        }

        // GET: CommenInfoes/Details/5
        public ActionResult Details(int? id)
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

        // GET: CommenInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommenInfoes/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "id,userid,contentid,url,title,commen")] CommenInfo commenInfo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.CommenInfo.Add(commenInfo);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(commenInfo);
        //}
        public ActionResult Create(string userid,string contentid)
        {
            int cid = Convert.ToInt16(contentid);
            int content_id = Convert.ToInt16(contentid);
            CommenInfo ci = new CommenInfo();
            if(ModelState.IsValid)
            {
                
                int id=0;
                int uid = Convert.ToInt16(userid);
                
                if (Convert.ToInt16(Session["userID"].ToString()) != null)
                {
                    id = Convert.ToInt16(Session["userID"].ToString());
                }
                
                ci.contentid = cid;

                var data = (from c in db.ContentInfo
                            where c.id == cid
                            select c).FirstOrDefault();
                if(data != null)
                {
                    ci.title = data.title;
                    ci.url = data.url;
                }
                else
                {
                    throw new Exception();
                }
                db.CommenInfo.Add(ci);
                db.SaveChanges();
                return Content("OK");
            }
            return View(ci);
        }

        // GET: CommenInfoes/Edit/5
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
                return RedirectToAction("Index");
            }
            return View(commenInfo);
        }

        // GET: CommenInfoes/Delete/5
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
