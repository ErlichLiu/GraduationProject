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
    public class CollectionInfoesController : Controller
    {
        private DayUpEntities1 db = new DayUpEntities1();

        // GET: CollectionInfoes
        public ActionResult Index()
        {
            return View(db.CollectionInfo.ToList());
        }

        // GET: CollectionInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectionInfo collectionInfo = db.CollectionInfo.Find(id);
            if (collectionInfo == null)
            {
                return HttpNotFound();
            }
            return View(collectionInfo);
        }

        // GET: CollectionInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CollectionInfoes/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "id,user_id,title,url")] CollectionInfo collectionInfo)
        public ActionResult Create(string user_id, string content_id)
        {
            CollectionInfo ci = new CollectionInfo();
            if (ModelState.IsValid)
            {
                int id = 0;
                int userid = Convert.ToInt16(user_id);
                int contentid = Convert.ToInt16(content_id);
                if( Convert.ToInt16(Session["userID"].ToString())!=null)
                {
                    id = Convert.ToInt16(Session["userID"].ToString());
                }
                ci.user_id = id;
                ci.content_id = contentid;
                var data = (from c in db.ContentInfo
                           where c.id == contentid
                           select c).FirstOrDefault();
                if(data!=null)
                {
                    ci.title = data.title;
                    ci.url = data.url;
                }
                else
                {
                    throw new Exception();
                }
                
                db.CollectionInfo.Add(ci);
                db.SaveChanges();
                return Content("OK");
                //return RedirectToAction("Index");
            }

            return View(ci);
        }

        // GET: CollectionInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectionInfo collectionInfo = db.CollectionInfo.Find(id);
            if (collectionInfo == null)
            {
                return HttpNotFound();
            }
            return View(collectionInfo);
        }

        // POST: CollectionInfoes/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,user_id,title,url")] CollectionInfo collectionInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collectionInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(collectionInfo);
        }

        // GET: CollectionInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollectionInfo collectionInfo = db.CollectionInfo.Find(id);
            if (collectionInfo == null)
            {
                return HttpNotFound();
            }
            return View(collectionInfo);
        }

        // POST: CollectionInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CollectionInfo collectionInfo = db.CollectionInfo.Find(id);
            db.CollectionInfo.Remove(collectionInfo);
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
