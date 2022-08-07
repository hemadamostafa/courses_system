using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class StudentStates
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public int NumberOfCourses { get; set; }
        public decimal Average { get; set; }
        public string ImageUrl { get; set; }
    }
}