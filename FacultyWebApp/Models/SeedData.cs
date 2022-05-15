using FacultyWebApp.Areas.Identity.Data;
using FacultyWebApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyWebApp.Models
{
    public class SeedData
    {
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<FacultyWebAppUser>>();
            IdentityResult roleResult;
            //Add Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck) { roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin")); }
            FacultyWebAppUser user = await UserManager.FindByEmailAsync("admin@faculty.com");
            if (user == null)
            {
                var User = new FacultyWebAppUser();
                User.Email = "admin@faculty.com";
                User.UserName = "admin@faculty.com";
                string userPWD = "Admin123";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                //Add default User to Role Admin
                if (chkUser.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User, "Admin"); }
            }

            var roleCheck1 = await RoleManager.RoleExistsAsync("Professor");
            if (!roleCheck1) { roleResult = await RoleManager.CreateAsync(new IdentityRole("Professor")); }
            FacultyWebAppUser user1 = await UserManager.FindByEmailAsync("professor@faculty.com");
            if (user1 == null)
            {
                var User = new FacultyWebAppUser();
                User.Email = "professor@faculty.com";
                User.UserName = "professor@faculty.com";
                string userPWD = "Professor123";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                //Add default User to Role Admin
                if (chkUser.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User, "Professor"); }
            }

            var roleCheck2 = await RoleManager.RoleExistsAsync("Student");
            if (!roleCheck2) { roleResult = await RoleManager.CreateAsync(new IdentityRole("Student")); }
            FacultyWebAppUser user2 = await UserManager.FindByEmailAsync("student@faculty.com");
            if (user2 == null)
            {
                var User = new FacultyWebAppUser();
                User.Email = "student@faculty.com";
                User.UserName = "student@faculty.com";
                string userPWD = "Student123";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                //Add default User to Role Admin
                if (chkUser.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User, "Student"); }
            }
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FacultyWebAppContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<FacultyWebAppContext>>()))
            {
                CreateUserRoles(serviceProvider).Wait();
                // Look for any movies.
                if (context.Course.Any() || context.Student.Any() || context.Teacher.Any())
                {
                    return; // DB has been seeded
                }
                context.Teacher.AddRange(
                new Teacher { /*Id = 1, */FirstName = "Rob", LastName = "Reiner", Degree = "FEIT", AcademicRank = "Doktor"},
                new Teacher { /*Id = 2, */FirstName = "Ivan", LastName = "Reitman", Degree = "PMF", AcademicRank = "Docent"},
                new Teacher { /*Id = 3, */FirstName = "Howard", LastName = "Hawks", Degree = "FINKI", AcademicRank = "Magister" }
                );
                context.SaveChanges();
                context.Student.AddRange(
                new Student { /*Id = 1, */FirstName = "Billy", LastName = "Crystal", AcquiredCredits = 50 },
                new Student { /*Id = 2, */FirstName = "Meg", LastName = "Ryan", AcquiredCredits = 45 },
                new Student { /*Id = 3, */FirstName = "Carrie", LastName = "Fisher", AcquiredCredits = 45 },
                new Student { /*Id = 4, */FirstName = "Bill", LastName = "Murray", AcquiredCredits = 45 },
                new Student { /*Id = 5, */FirstName = "Dan", LastName = "Aykroyd", AcquiredCredits = 45 },
                new Student { /*Id = 6, */FirstName = "Sigourney", LastName = "Weaver", AcquiredCredits = 45 },
                new Student { /*Id = 7, */FirstName = "John", LastName = "Wayne", AcquiredCredits = 45 },
                new Student { /*Id = 8, */FirstName = "Dean", LastName = "Martin", AcquiredCredits = 45 }
                );
                context.SaveChanges();
                context.Course.AddRange(
                new Course
                {
                    //Id = 1,
                    Title = "Basics of Object-oriented programming",
                    Credits = 6,
                    Semester = 3,
                    Programme = "KTI",
                    FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Rob" && d.LastName == "Reiner").TeacherId,
      
                },
                new Course
                {
                    //Id = 2,
                    Title = "Advanced Algebra",
                    Credits = 8,
                    Semester = 6,
                    Programme = "KSIAR",
                    FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Ivan" && d.LastName == "Reitman").TeacherId,
                    SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Howard" && d.LastName == "Hawks").TeacherId
                },
                new Course
                {
                    //Id = 3,
                    Title = "Computer Networks",
                    Credits = 4,
                    Semester = 5,
                    Programme = "KTI",
                    FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Howard" && d.LastName == "Hawks").TeacherId,
                    
                }
                );
                context.SaveChanges();
                context.Enrollment.AddRange
                (
                new Enrollment { StudentId = 1, CourseId = 1 },
                new Enrollment { StudentId = 2, CourseId = 1 },
                new Enrollment { StudentId = 3, CourseId = 1 },
                new Enrollment { StudentId = 4, CourseId = 2 },
                new Enrollment { StudentId = 5, CourseId = 2 },
                new Enrollment { StudentId = 6, CourseId = 2 },
                new Enrollment { StudentId = 4, CourseId = 3 },
                new Enrollment { StudentId = 5, CourseId = 3 },
                new Enrollment { StudentId = 6, CourseId = 3 }
                );
                context.SaveChanges();
            }
        }
        }
}
