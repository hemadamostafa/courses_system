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
    public class HomeController : BaisController
    {
        private SchoolEntities db = new SchoolEntities();
        [AllowAnonymous]
        public ActionResult Index()
        {
            var x = db.Carousels.ToList();
            ViewBag.Carousel = db.Carousels.ToList();
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
    }
}