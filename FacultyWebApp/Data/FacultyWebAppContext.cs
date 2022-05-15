using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FacultyWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FacultyWebApp.Areas.Identity.Data;

namespace FacultyWebApp.Data
{
    public class FacultyWebAppContext : IdentityDbContext<FacultyWebAppUser>
    {
        public FacultyWebAppContext (DbContextOptions<FacultyWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<FacultyWebApp.Models.Course> Course { get; set; }

        public DbSet<FacultyWebApp.Models.Teacher> Teacher { get; set; }

        public DbSet<FacultyWebApp.Models.Student> Student { get; set; }

        public DbSet<FacultyWebApp.Models.Enrollment> Enrollment { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
