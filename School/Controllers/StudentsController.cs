using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using School.Models;
using System.IO;

namespace School.Controllers
{
    public class StudentsController : BaisController
    {
        private SchoolEntities db = new SchoolEntities();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //.Where(e=>e.StudentId == id)

            //var enroll = db.Enrollments.ToList();
            //var Result = new List<Course>();
            //foreach (var item in db.Courses)
            //{
            //    if(item.CourseId == enroll.CourseId)
            //    Result.Add(item);
            //}

            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student,HttpPostedFileBase profileImg)
        {
            if (ModelState.IsValid)
            {
                if(profileImg.FileName.Length > 0)
                {
                    string Path = "/Content/Images/" + profileImg.FileName;
                    profileImg.SaveAs(Server.MapPath(Path));
                    student.ImagePath = Path;
                }
                
                                
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,FirstName,LastName,EnrollmentDate")] Student student,HttpPostedFileBase profileImg)
        {
            if (ModelState.IsValid)
            {
                if(!string.IsNullOrWhiteSpace(profileImg.FileName))
                {
                    string way = "/Content/Images/" + profileImg.FileName;
                    profileImg.SaveAs(Server.MapPath(way));
                    student.ImagePath = way;
                }
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
