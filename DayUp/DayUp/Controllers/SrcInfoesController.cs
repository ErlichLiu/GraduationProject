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
    public class SrcInfoesController : Controller
    {
        private DayUpEntities1 db = new DayUpEntities1();

        // GET: SrcInfoes
        public ActionResult Index()
        {
            return View(db.SrcInfo.ToList());
        }

        // GET: SrcInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SrcInfo srcInfo = db.SrcInfo.Find(id);
            if (srcInfo == null)
            {
                return HttpNotFound();
            }
            return View(srcInfo);
        }

        // GET: SrcInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SrcInfoes/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,type,websitename")] SrcInfo srcInfo)
        {
            if (ModelState.IsValid)
            {
                db.SrcInfo.Add(srcInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(srcInfo);
        }

        // GET: SrcInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SrcInfo srcInfo = db.SrcInfo.Find(id);
            if (srcInfo == null)
            {
                return HttpNotFound();
            }
            return View(srcInfo);
        }

        // POST: SrcInfoes/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type,websitename")] SrcInfo srcInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(srcInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(srcInfo);
        }

        // GET: SrcInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SrcInfo srcInfo = db.SrcInfo.Find(id);
            if (srcInfo == null)
            {
                return HttpNotFound();
            }
            return View(srcInfo);
        }

        // POST: SrcInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SrcInfo srcInfo = db.SrcInfo.Find(id);
            db.SrcInfo.Remove(srcInfo);
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
