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
    public class CarouselsController : BaisController
    {
        private SchoolEntities db = new SchoolEntities();

        // GET: Carousels
        public ActionResult Index()
        {
            return View(db.Carousels.ToList());
        }

        // GET: Carousels/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carousel carousel = db.Carousels.Find(id);
            if (carousel == null)
            {
                return HttpNotFound();
            }
            return View(carousel);
        }

        // GET: Carousels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carousels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Carousel carousel,HttpPostedFileBase Image)
        {
            if(Image.FileName.Length > 0)
            {
                var path = "/Content/Carousel" + Image.FileName;
                Image.SaveAs(Server.MapPath(path));
                if (ModelState.IsValid)
                {
                    carousel.Image = path;
                    db.Carousels.Add(carousel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }else
            {
                return View(carousel);
            }

            return View(carousel);
        }

        // GET: Carousels/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carousel carousel = db.Carousels.Find(id);
            if (carousel == null)
            {
                return HttpNotFound();
            }
            return View(carousel);
        }

        // POST: Carousels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SlideId,Image,SlideTitle,SubTitle")] Carousel carousel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carousel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carousel);
        }

        // GET: Carousels/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carousel carousel = db.Carousels.Find(id);
            if (carousel == null)
            {
                return HttpNotFound();
            }
            return View(carousel);
        }

        // POST: Carousels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            Carousel carousel = db.Carousels.Find(id);
            db.Carousels.Remove(carousel);
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
