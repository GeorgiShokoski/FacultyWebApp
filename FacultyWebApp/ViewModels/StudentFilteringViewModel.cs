using FacultyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyWebApp.ViewModels
{
    public class StudentFilteringViewModel
    {
        public IList<Student> Students { get; set; }
        public string SearchString { get; set; }

        public string SearchString1 { get; set; }
    }
}
