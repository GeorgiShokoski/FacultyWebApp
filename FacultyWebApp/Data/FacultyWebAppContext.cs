using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FacultyWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FacultyWebApp.Data
{
    public class FacultyWebAppContext : DbContext
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
            builder.Entity<Enrollment>()
            .HasOne<Student>(p => p.Student)
            .WithMany(p => p.Courses)
            .HasForeignKey(p => p.StudentId);
            
            builder.Entity<Enrollment>()
            .HasOne<Course>(p => p.Course)
            .WithMany(p => p.Students)
            .HasForeignKey(p => p.CourseId);
        }
    }
}
