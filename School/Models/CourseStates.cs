using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Models
{//thats view model
    public class CourseStates
    {
        public string CourseTitle { get; set; }
        public int CourseEnrollments { get; set; }

        public int DetailId { get; set; }
    }
}