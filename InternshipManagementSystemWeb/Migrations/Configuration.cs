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

            ///////////////////////////////////////////////////////////////////  Seeding:

            //Add examples of Admins
            //var admins = new List<Admin>
            //    {
            //          new Admin {EmployeeUniversityId = "2012", FirstName = "Mervat", LastName = "Khodary", Office = "370",
            //        Email = "mkhodary@dah.edu.sa", Phone = "6000012", Extension = "64" //Mobile = "0543222210" 
            //          },
            //    };

            //admins.ForEach(c => context.Admins.AddOrUpdate(m => m.EmployeeUniversityId, c));
            //context.SaveChanges();

            // Add examples of Instructors
            //var instructors = new List<Instructor>
            //    {
            //     new Instructor
            //        {
            //        EmployeeUniversityId = "1234", FirstName = "Huda", LastName = "Saied", Office = "301",
            //        Email = "hsaied@dah.edu.sa", Phone = "6000012", Extension = "55" //Mobile = "0555432123"
            //        },
            //     new Instructor
            //        {
            //        EmployeeUniversityId = "2345", FirstName = "Salma", LastName = "Nasif", Office = "064",
            //        Email = "snasif@dah.edu.sa", Phone = "6000012", Extension = "23" //Mobile = "0543243215"
            //        },
            //     new Instructor
            //        {
            //        EmployeeUniversityId = "5678", FirstName = "Hanaa", LastName = "Haitham", Office = "211",
            //        Email = "hhaitham@dah.edu.sa", Phone = "6000012", Extension = "70" //Mobile = "0598734503"
            //        },
            //     new Instructor
            //        {
            //        EmployeeUniversityId = "1223", FirstName = "Samar", LastName = "Alafan", Office = "332",
            //        Email = "salafan@dah.edu.sa", Phone = "6000012", Extension = "35" //Mobile = "0543211298"
            //        },
            //     new Instructor
            //        {
            //        EmployeeUniversityId = "4503", FirstName = "Amal", LastName = "Alsamad", Office = "119",
            //        Email = "aalsamad@dah.edu.sa", Phone = "6000012", Extension = "88" //Mobile = "0500054321"
            //        },
            ////    };

            //instructors.ForEach(c => context.Instructors.AddOrUpdate(m => m.EmployeeUniversityId, c));
            //context.SaveChanges();

            // Add examples of announceements
            var announcements = new List<Announcement>
                {
                    new Announcement {Subject = "Graphic Design needed",
                        Description = "Internship opportunity for graphic design students, three students needed, send your portfolio" },
                    new Announcement {Subject = "HR Internship opportunity",
                        Description = "Internhsip student majored in HR needed, three months internship program" },
                    new Announcement {Subject = "Coop program for MIS",
                        Description = "Savola is offering a trained coop program for MIS students" },
                    new Announcement {Subject = "STEAM Compitition",
                        Description = "Limited opportunity for all student to joing the challenge" }
                };
            announcements.ForEach(c => context.Announcements.AddOrUpdate(m => m.Subject, c));
            context.SaveChanges();

            // Add examples of attendances
            //var attendances = new List<Attendance>
            //    {
            //        new Attendance {AttendanceDate = },

            //    };
            //attendances.ForEach(c => context.Attendances.AddOrUpdate(m => m.AttendanceDate, c));
            //context.SaveChanges();

            //Add examples of complains
            //var complains = new List<Complain>
            //    {
            //          new Complain {},                
            //    };
            //complains.ForEach(c => context.Complains.AddOrUpdate(m => m.Title, c));
            //context.SaveChanges();

            // Add examples of firms
            var firms = new List<Firm>
                {
                    new Firm { FirmName = "Unilever", Address = "8770 King Abdulaziz Branch Rd, Ash Shati, Jeddah 23514-3261 https://goo.gl/maps/XdUEEe8v4zS2",
                        NumberOfVacencies = 10, IndustryField = "Consumer Goods"},
                    new Firm { FirmName = "NCB", Address = "Al Shaty, Jeddah 23513 https://goo.gl/maps/Hs5rjJgj6NA2",
                        NumberOfVacencies = 9, IndustryField = "Banking and Finance"},
                    new Firm { FirmName = "Savola", Address = "Prince Faisal Bin Fahd, Ash Shati, Jeddah 23513 https://goo.gl/maps/7FyRoS3NSLw",
                        NumberOfVacencies = 2, IndustryField = "Investment Management"}
                };

            firms.ForEach(c => context.Firms.AddOrUpdate(m => m.FirmName, c));
            context.SaveChanges();

            //Add examples of Sections
            var sections = new List<Section>
                {
                      new Section {Semester = Semester.SummerI, Year = 2018, Capacity = 20},
                      new Section {Semester = Semester.Fall, Year = 2019, Capacity = 20},
                      new Section {Semester = Semester.Fall, Year = 2019, Capacity = 15},
                      new Section {Semester = Semester.Spring, Year = 2019, Capacity = 10}
                };

            sections.ForEach(c => context.Sections.AddOrUpdate(m => m.Semester, c));
            context.SaveChanges();

            // Add examples of internship courses
            var internshipCourses = new List<InternshipCourse>
                {
                    new InternshipCourse { CourseCode = "BBIS 4403", CourseName = "Internship: Business Information System",
                        Description = "Internship course for BIS students.", Credits = 3},
                    new InternshipCourse { CourseCode = "FINC", CourseName = "Internship: Banking and finance",
                        Description = "Internship course for Banking and finance students.", Credits = 3,}
                };

            internshipCourses.ForEach(c => context.InternshipCourses.AddOrUpdate(m => m.CourseName, c));
            context.SaveChanges();

            // Add examples of Supervisors
            var supervisors = new List<Supervisor>
                {
                    new Supervisor {FirstName = "Amal", LastName = "Al-Nahdi", Email = "amal-alnahdi@unilever.com",
                        Phone = "0126789009", Mobile = "0566665678", Department = "Human Resources", FirmId = 1},
                    new Supervisor {FirstName = "Zainab", LastName = "Bin Mahfoz", Email = "Zainabbinmahfoz@ncb.sa",
                        Phone = "0126654321", Mobile = "0554321234", Department = "Human Resources", FirmId = 2},
                     new Supervisor {FirstName = "Ahmad", LastName = "Abdulrahman", Email = "ahmadabdulrahman@savola.com",
                        Phone = "01267890000", Mobile = "0542222212", Department = "Human Resources", FirmId = 3},

                };
            supervisors.ForEach(c => context.Supervisors.AddOrUpdate(m => m.Email, c));
            context.SaveChanges();

        }
    }
}
