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
    public class ContentInfoesmanageController : Controller
    {
        private DayUpEntities1 db = new DayUpEntities1();

        // GET: ContentInfoesmanage
        public ActionResult Index()
        {
            return View(db.ContentInfo.ToList());
        }

        // GET: ContentInfoesmanage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentInfo contentInfo = db.ContentInfo.Find(id);
            if (contentInfo == null)
            {
                return HttpNotFound();
            }
            return View(contentInfo);
        }

        // GET: ContentInfoesmanage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContentInfoesmanage/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,summary,picurl,url,hot,websitename,type,time,claps,bigpicurl")] ContentInfo contentInfo)
        {
            if (ModelState.IsValid)
            {
                db.ContentInfo.Add(contentInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contentInfo);
        }

        // GET: ContentInfoesmanage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentInfo contentInfo = db.ContentInfo.Find(id);
            if (contentInfo == null)
            {
                return HttpNotFound();
            }
            return View(contentInfo);
        }

        // POST: ContentInfoesmanage/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,summary,picurl,url,hot,websitename,type,time,claps,bigpicurl")] ContentInfo contentInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contentInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contentInfo);
        }

        // GET: ContentInfoesmanage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentInfo contentInfo = db.ContentInfo.Find(id);
            if (contentInfo == null)
            {
                return HttpNotFound();
            }
            return View(contentInfo);
        }

        // POST: ContentInfoesmanage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContentInfo contentInfo = db.ContentInfo.Find(id);
            db.ContentInfo.Remove(contentInfo);
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
