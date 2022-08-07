using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    [MetadataType(typeof(StudentMetaData))]
    public partial class Student
    {

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        [MetadataType(typeof(EnrollmentMetaData))]
        public partial class Enrollment
        {
            [RecentEnrollment]
            public Nullable<System.DateTime> EnrollmentDate { get; set; }

            [MetadataType(typeof(CourseMetaData))]
            public partial class Course
            {

            }
        }
    }
}