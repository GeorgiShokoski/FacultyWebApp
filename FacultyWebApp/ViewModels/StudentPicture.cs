using FacultyWebApp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyWebApp.ViewModels
{
    public class StudentPicture
    {
        public Student Student { get; set; }

        [Display(Name = "Upload")]
        public IFormFile ProfilePictureFile { get; set; }

        [Display(Name = "Picture")]
        public string ProfilePictureName { get; set; }
    }
}
