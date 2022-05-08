using FacultyWebApp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyWebApp.ViewModels
{
    public class StudentEditViewModel
    {
        public Enrollment Enrollment { get; set; }

        [Display(Name = "Seminal File")]
        public IFormFile? SeminalUrlFile { get; set; }
        public string SeminalUrlName { get; set; }
    }
}
