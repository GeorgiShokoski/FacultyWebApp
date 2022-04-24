using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyWebApp.Models
{
    public class Student
    {
        [Required]
        public long StudentId { get; set; }

        [StringLength(10, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 5)]
        [Required]
        public string LastName { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        public int AcquiredCredits { get; set; }

        public int CurrentSemester { get; set; }

        [StringLength(25)]
        public string EducationLevel { get; set; }

        public ICollection<Enrollment> Courses { get; set; }
    }
}
