using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Student : Person 
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        public int? CreditEarned { get; set; }


        //public string Email { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "Only allowed two decimal digits")]
        [Range(0.7, 4.0)]
        public decimal? GPA { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}