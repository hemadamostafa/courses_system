using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using School.Models;

namespace School.Controllers
{
    public class CourseLevelController : Controller
    {
        private SchoolEntities db = new SchoolEntities();

        // GET: CourseLevel
        public ActionResult Index()
        {
            return View(db.CourseLevel1.ToList());
        }

        // GET: CourseLevel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseLevel1 courseLevel1 = db.CourseLevel1.Find(id);
            if (courseLevel1 == null)
            {
                return HttpNotFound();
            }
            return View(courseLevel1);
        }

        // GET: CourseLevel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseLevel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseLevelId,LevelTitle")] CourseLevel1 courseLevel1)
        {
            if (ModelState.IsValid)
            {
                db.CourseLevel1.Add(courseLevel1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseLevel1);
        }

        // GET: CourseLevel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseLevel1 courseLevel1 = db.CourseLevel1.Find(id);
            if (courseLevel1 == null)
            {
                return HttpNotFound();
            }
            return View(courseLevel1);
        }

        // POST: CourseLevel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseLevelId,LevelTitle")] CourseLevel1 courseLevel1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseLevel1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseLevel1);
        }

        // GET: CourseLevel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseLevel1 courseLevel1 = db.CourseLevel1.Find(id);
            if (courseLevel1 == null)
            {
                return HttpNotFound();
            }
            return View(courseLevel1);
        }

        // POST: CourseLevel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseLevel1 courseLevel1 = db.CourseLevel1.Find(id);
            db.CourseLevel1.Remove(courseLevel1);
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
