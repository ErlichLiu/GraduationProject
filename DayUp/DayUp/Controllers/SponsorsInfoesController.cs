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
    public class SponsorsInfoesController : Controller
    {
        private DayUpEntities1 db = new DayUpEntities1();

        // GET: SponsorsInfoes
        public ActionResult Index()
        {
            return View(db.SponsorsInfo.ToList());
        }

        // GET: SponsorsInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SponsorsInfo sponsorsInfo = db.SponsorsInfo.Find(id);
            if (sponsorsInfo == null)
            {
                return HttpNotFound();
            }
            return View(sponsorsInfo);
        }

        // GET: SponsorsInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SponsorsInfoes/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,logourl,money,url")] SponsorsInfo sponsorsInfo)
        {
            if (ModelState.IsValid)
            {
                db.SponsorsInfo.Add(sponsorsInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sponsorsInfo);
        }

        // GET: SponsorsInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SponsorsInfo sponsorsInfo = db.SponsorsInfo.Find(id);
            if (sponsorsInfo == null)
            {
                return HttpNotFound();
            }
            return View(sponsorsInfo);
        }

        // POST: SponsorsInfoes/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,logourl,money,url")] SponsorsInfo sponsorsInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sponsorsInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sponsorsInfo);
        }

        // GET: SponsorsInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SponsorsInfo sponsorsInfo = db.SponsorsInfo.Find(id);
            if (sponsorsInfo == null)
            {
                return HttpNotFound();
            }
            return View(sponsorsInfo);
        }

        // POST: SponsorsInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SponsorsInfo sponsorsInfo = db.SponsorsInfo.Find(id);
            db.SponsorsInfo.Remove(sponsorsInfo);
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
