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
    
    public class CoursesController : BaisController
    {
        private SchoolEntities db = new SchoolEntities();

        // GET: Courses
        //public ActionResult Index()
        //{
        //    return View(db.Courses.ToList());
        //}

        public ActionResult Index(string Search)
        {
            var courses = from c in db.Courses
                          select c;
            if (!String.IsNullOrEmpty(Search))
            {
                courses = courses.Where(s => s.Title.Contains(Search));
            }
            return View(courses.ToList());
        }

        public JsonResult GetSrearch (string search)
        {
            var suggesion = db.Courses.Where(c => c.Title.Contains(search)).Select(x => new { Title = x.Title }).ToList();
            return new JsonResult { Data = suggesion, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //GET: Courses
        [HttpGet]
        public ActionResult IndexMultiDelete()
        {
            return View(db.Courses.ToList());
        }

        [HttpPost]
        public ActionResult IndexMultiDelete(FormCollection formcollection)
        {
            string[] ids = formcollection["Id"].Split(new char[] { ',' });
            foreach (var item in ids)
            {
                Course course = db.Courses.Find(int.Parse(item));
                db.Courses.Remove(course);
            }
            db.SaveChanges();
            //return Json(true, JsonRequestBehavior.AllowGet);
            return View(db.Courses.ToList());
        }

        public ActionResult Test()
        {
            var course = new Course();
            course.Level = CourseLevel.Intermediat;
            return View(db.GetCourse().ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.levels = db.CourseLevel1.ToList();
            //ViewBag.levels = new SelectList(db.CourseLevel1,"CourseLevelId","LevelTitle");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,Title,credits,Level,CourseDescription,IsActive,Rating")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteConfirmedJSON(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return Json(false,JsonRequestBehavior.AllowGet);
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
