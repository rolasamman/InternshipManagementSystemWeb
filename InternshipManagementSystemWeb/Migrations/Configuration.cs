namespace InternshipManagementSystemWeb.Migrations
{
    using InternshipManagementSystemWeb.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InternshipManagementSystemWeb.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)

        {
            //TODO Define roles to add to your app, keep the Admin role first
            string[] roles = { "Admin", "Instructor", "Student" };


            //TODO Change admin user login information

            string adminEmail = "admin@dah.edu";

            string adminUserName = "admin@dah.edu";

            string adminPassword = "admin123";

            // Create roles
            var roleStore = new CustomRoleStore(context);
            var roleManager = new RoleManager<CustomRole, int>(roleStore);

            foreach (var role in roles)
            {
                if (!roleManager.RoleExists(role))
                {
                    roleManager.Create(new CustomRole { Name = role });
                }
            }

            // Define admin user
            var userStore = new CustomUserStore(context);
            var userManager = new ApplicationUserManager(userStore);

            //TODO Change the type of the admin user

            var admin = new ApplicationUser
            {
                UserName = adminUserName,
                Email = adminEmail,
                EmailConfirmed = true,
                LockoutEnabled = false
            };

            // Create admin user
            if (userManager.FindByName(admin.UserName) == null)

            {
                userManager.Create(admin, adminPassword);
            }

            // Add admin user to admin role

            // roles[0] is "Admin"

            var user = userManager.FindByName(admin.UserName);
            if (!userManager.IsInRole(user.Id, roles[0]))
            {
                userManager.AddToRole(admin.Id, roles[0]);
            }

            // Add examples of Sections
            var sections = new List<Section>
            {
                  new Section {Semester = Semester.Fall, Year = 2019, Capacity = 20 },
                  new Section {Semester = Semester.Spring, Year = 2019, Capacity = 20 },
                  new Section {Semester = Semester.Fall, Year = 2019, Capacity = 15 },
                  new Section {Semester = Semester.Fall, Year = 2019, Capacity = 10 }
            };

            // Add examples of internship courses
            var Course = new List<InternshipCourse>
            {
                new InternshipCourse { CourseCode = "BBIS 4403", CourseName = "Internship: Business Information System",
                    Description = "Internship course for BIS students.", Credits = 3},
                new InternshipCourse { CourseCode = "FINC", CourseName = "Internship: Banking and finance",
                    Description = "Internship course for Banking and finance students.", Credits = 3,},

            };

            // Add examples of firms
            var Firm = new List<Firm>
            {
                new Firm { FirmName = "Unilever", Address = "8770 King Abdulaziz Branch Rd, Ash Shati, Jeddah 23514-3261 https://goo.gl/maps/XdUEEe8v4zS2",
                    NumberOfVacencies = 10, IndustryField = "Consumer Goods"},
                new Firm { FirmName = "NCB", Address = "Al Shaty, Jeddah 23513 https://goo.gl/maps/Hs5rjJgj6NA2",
                    NumberOfVacencies = 9, IndustryField = "Banking and Finance"}
            };
        }
    }
}
