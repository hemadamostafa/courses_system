using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class RecentEnrollment:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var std = (Student)validationContext.ObjectInstance;
            if (std.EnrollmentDate == null)
            {
                return new ValidationResult("Enrollment Date is requerd");
            }
            return ValidationResult.Success;
            /*else
            {
                var age = DateTime.Today.Year - std.EnrollmentDate;
                if (age > 3)
                {
                    return new ValidationResult("This Enrollment Is very Old");
                }else
                {
                    return ValidationResult.Success;
                }
            }*/
        }
    }
}