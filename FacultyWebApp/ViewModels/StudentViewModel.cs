using FacultyWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyWebApp.ViewModels
{
    public class StudentViewModel
    {
        public List<Student> Students { get; set; }
        public SelectList IDs { get; set; }
        public int studentIndex { get; set; }
    }
}
