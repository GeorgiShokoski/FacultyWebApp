using FacultyWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyWebApp.ViewModels
{
    public class CourseStudentsEditViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<long> SelectedStudents { get; set; }
        public IEnumerable<SelectListItem> StudentList { get; set; }
        public string ProjectUrl { get; set; }
    }
}
