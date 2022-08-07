using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class BaisController : Controller
    {
        private SchoolEntities db = new SchoolEntities();
        static List<CourseStates> States = null;
        static List<StudentStates> StudentStates = null;
        public BaisController()
        {
            //Courses States
            States = new List<CourseStates>();
            var coursesGroups = db.Enrollments.GroupBy(e => e.Course.Title);
            var coursesIds = from course in db.Courses select course.CourseId;
            var Ids = coursesIds.ToList();
            var counter = 0;
            foreach (var group in coursesGroups)
            {
                States.Add(new CourseStates { CourseTitle = group.Key,CourseEnrollments = group.Count() , DetailId = Ids[counter]});
                counter++;
            }
            ViewBag.States = States;
            // Students States
            StudentStates = new List<StudentStates>();
            var StdsTop = db.Enrollments.GroupBy(s => s.StudentId).Select(g => new StudentStates {
                StudentId = g.Key,
                FullName = g.FirstOrDefault().Student.FirstName,
                NumberOfCourses = g.Count(),
                Average = (decimal) g.Average(s=>s.Grade),
                ImageUrl = g.FirstOrDefault().Student.ImagePath,
            }).OrderByDescending(x=>x.Average).Take(3).ToList();
            ViewBag.StdsTop = StdsTop;
        }
    }
}