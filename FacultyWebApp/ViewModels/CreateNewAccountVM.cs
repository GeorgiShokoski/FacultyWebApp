using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyWebApp.ViewModels
{
    public class CreateNewAccountVM
    {
        public IEnumerable<SelectListItem>? TeacherList { get; set; }
        public IEnumerable<int>? SelectedTeacher { get; set; }
    }
}
