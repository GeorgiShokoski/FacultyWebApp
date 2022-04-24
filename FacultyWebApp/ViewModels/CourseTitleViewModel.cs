using FacultyWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyWebApp.ViewModels
{
    public class CourseTitleViewModel
    {
        public IList<Course> Courses { get; set; }
        public string SearchSTring { get; set; }
        public string SearchString1 { get; set; }
        public int CourseSemester { get; set; }
        public SelectList Semesters { get; set; }
    }
}
