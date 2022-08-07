using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class CourseMetaData
    {
        [Required(ErrorMessage ="You Must Enter Title")]
        public string Title { get; set; }
        [Range(2,25,ErrorMessage ="The credit must be between 2 and 25 Hours")]
        public int credits { get; set; }
        [Display(Name ="Description")]
        public string CourseDescription { get; set; }
        public Nullable<int> Price { get; set; }
        public bool IsActive { get; set; }
        [Required]
        //[EnumDataType(typeof(CourseLevel))]
        public Nullable<CourseLevel> Level2 { get; set; }
        [EnumDataType(typeof(RatingLevel))]
        public Nullable<RatingLevel> Rating { get; set; }
    }

    public class StudentMetaData
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [RecentEnrollment]
        public Nullable<System.DateTime> EnrollmentDate { get; set; }
        public string ImagePath { get; set; }
        public Nullable<int> Salary { get; set; }
    }

    public class EnrollmentMetaData
    {
        [Range(0,100,ErrorMessage ="Please Enter Number between 0 and 100")]
        public Nullable<decimal> Grade { get; set; }
    }
}