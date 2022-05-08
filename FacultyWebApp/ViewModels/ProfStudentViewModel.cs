using FacultyWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyWebApp.ViewModels
{
    public class ProfStudentViewModel
    {
        public List<Enrollment> enrollments { get; set; }
        public SelectList yearlist { get; set; }
        public int? year { get; set; }
    }
}
