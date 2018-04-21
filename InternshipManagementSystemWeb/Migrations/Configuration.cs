/*    
 *      Description:    This is an Internship Management System for a university. 
 *                      The project handles internship matters of the internship department of the university. 
 *                      The aim of the project is to make communications between users most efficient and effective. 
 *                      It also provides users with necessary data and records needed information.
 *      
 *      Author:         Rola Samman
*/

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
            // Roles 
            string[] roles = { "Admin", "Instructor", "Student" };

            // Admin user login information

            string adminEmail = "admin@dah.edu";

            string adminUserName = "admin";

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

            // Type of the admin user

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

            //Add example of admin employees
            var employees = new List<Employee>
                {
                      new Employee {
                          Id = 10,
                          UserName = "mismail",
                          //PasswordHash = "m123123",
                          EmployeeUniversityId = "2012",
                          FirstName = "Mervat",
                          LastName = "Ismail",
                          Office = "370",
                          Email = "mismail@dah.edu.sa",
                          Phone = "6000012",
                          Extension = "64",
                          Mobile = "0543222210",
                          
                      },
                };

            // Employees user login information
            // Employees are all working individual in the university 
            // Employees can be admin or instructor 

            string employeePassword = "dah2018";

            foreach (var employee in employees)
            {
                if (userManager.FindByName(employee.UserName) == null)
                {
                    userManager.Create(employee, employeePassword );
                }

                var usertemp = userManager.FindByName(admin.UserName);
                if (!userManager.IsInRole(usertemp.Id, roles[0]))
                {
                    userManager.AddToRole(usertemp.Id, roles[0]);
                }
            }

            // Add examples of Instructors
            var instructors = new List<Instructor>
                {
                 new Instructor
                    {
                     Id = 20,
                     UserName = "hsaied",
                     //PasswordHash = "h123123",
                     EmployeeUniversityId = "1234",
                     FirstName = "Huda",
                     LastName = "Saied",
                     Office = "301",
                     Email = "hsaied@dah.edu.sa",
                     Phone = "6000012",
                     Extension = "55",
                     Mobile = "0555432123",
                     Department = Department.BusinessAndLaw
                    },
                 new Instructor
                    {
                     Id = 21,
                     UserName = "snasif",
                     EmployeeUniversityId = "2345",
                     FirstName = "Salma",
                     LastName = "Nasif",
                     Office = "064",
                     Email = "snasif@dah.edu.sa",
                     Phone = "6000012",
                     Extension = "23",
                     Mobile = "0543243215",
                     Department = Department.BusinessAndLaw
                    },
                 new Instructor
                    {
                     Id = 22, 
                     UserName = "hhaitham",
                     EmployeeUniversityId = "5678",
                     FirstName = "Hanaa",
                     LastName = "Haitham",
                     Office = "211",
                     Email = "hhaitham@dah.edu.sa",
                     Phone = "6000012",
                     Extension = "70",
                     Mobile = "0598734503",
                     Department = Department.DesignAndArchitecture
                    },
                 new Instructor
                    {
                     Id = 23,
                     UserName = "salafan",
                     EmployeeUniversityId = "1223",
                     FirstName = "Samar",
                     LastName = "Alafan",
                     Office = "332",
                     Email = "salafan@dah.edu.sa",
                     Phone = "6000012",
                     Extension = "35",
                     Mobile = "0543211298",
                     Department = Department.DesignAndArchitecture
                    },
                 new Instructor
                    {
                     Id = 24,
                     UserName = "aalsamad",
                     EmployeeUniversityId = "4503",
                     FirstName = "Amal",
                     LastName = "Alsamad",
                     Office = "119",
                     Email = "aalsamad@dah.edu.sa",
                     Phone = "6000012",
                     Extension = "88",
                     Mobile = "0500054321",
                     Department = Department.BusinessAndLaw
                     }
                };

            // Instructors user employee login password. 

            foreach (var instructor in instructors)
            {
                if (userManager.FindByName(instructor.UserName) == null)
                {
                    userManager.Create(instructor, employeePassword);
                }

                var usertemp = userManager.FindByName(instructor.UserName);
                if (!userManager.IsInRole(usertemp.Id, roles[1]))
                {
                    userManager.AddToRole(usertemp.Id, roles[1]);
                }
            }

            // Add examples of announceements
            var announcements = new List<Announcement>
                {
                    new Announcement {
                        Subject = "Graphic Design Student Needed",
                        AnnouncementDate = new DateTime(2018,2,3),
                        Description = "Internship opportunity for graphic design students, three students needed, send your portfolio" },
                    new Announcement {
                        Subject = "HR Internship opportunity",
                        AnnouncementDate = new DateTime(2018,2,11),
                        Description = "Internhsip student majored in HR needed, three months internship program" },
                    new Announcement {
                        Subject = "Coop Program for MIS",
                        AnnouncementDate = new DateTime(2018,3,4),
                        Description = "Savola is offering a trained coop program for MIS students" },
                    new Announcement {
                        Subject = "STEAM Challenge",
                        AnnouncementDate = new DateTime(2018,3,7),
                        Description = "Limited opportunity for all student to joing the challenge" }
                };

            announcements.ForEach(c => context.Announcements.AddOrUpdate(m => m.Subject, c));
            context.SaveChanges();

            // Add examples of attendances
            var attendances = new List<Attendance>
                {
                    new Attendance {
                        AttendanceId = 1,
                        AttendanceDate = new DateTime(2018,2,3),
                        TimeIn = new TimeSpan(8,30,0),
                        TimeOut = new TimeSpan(16,30,0),
                        Description = "Observing and learning about the work environment",
                        //StudentId = 50,
                        //FirmId = 1
                    },
                    new Attendance {
                        AttendanceId = 2,
                        AttendanceDate = new DateTime(2018,2,11),
                        TimeIn = new TimeSpan(9,0,0),
                        TimeOut = new TimeSpan(17,0,0),
                        Description = "Meeting with the employees and asking them questions",
                        //StudentId = 51,
                        //FirmId = 2
                    },
                    new Attendance {
                        AttendanceId = 3,
                        AttendanceDate = new DateTime(2018,2,20),
                        TimeIn = new TimeSpan(8,0,0) ,
                        TimeOut = new TimeSpan(16,0,0),
                        Description = "Reviewing assigned tasks with the supervisor",
                        //StudentId = 52,
                        //FirmId = 3
                    },
                };

            attendances.ForEach(c => context.Attendances.AddOrUpdate(m => m.AttendanceDate, c));
            context.SaveChanges();

            //Add examples of complains
            var complains = new List<Complain>
                {
                      new Complain {
                      Title = "Work place is not friendly",
                      CreationDate = new DateTime(2018,3,20),
                      Description = "Supervisor has not guid me through the company",
                      ComplainStatus = ComplainStatus.Submitted
                      },
                      new Complain {
                      Title = "No place to work",
                      CreationDate = new DateTime(2018,3,17),
                      Description = "Supervisor has not provide me with an office or desk or a place to work",
                      ComplainStatus = ComplainStatus.InProgress
                      },
                        new Complain {
                      Title = "Uncomfortable work environment",
                      CreationDate = new DateTime(2018,3,26),
                      Description = "The office is crowded with people all the time",
                      ComplainStatus = ComplainStatus.Viewed
                      },
                };

            complains.ForEach(c => context.Complains.AddOrUpdate(m => m.Title, c));
            context.SaveChanges();

            // Add examples of firms
            var firms = new List<Firm>
                {
                    new Firm {
                        FirmName = "Unilever",
                        FirmDescription = "Be part of the world’s most successful, purpose-led business. " +
                        "Work with brands that are well-loved around the world, that improve the lives " +
                        "of our consumers and the communities around us.",
                        Address = "8770 King Abdulaziz Branch Rd, Ash Shati, Jeddah 23514-3261",
                        MapLink = "https://goo.gl/maps/XdUEEe8v4zS2",
                        NumberOfVacencies = 10,
                        IndustryField = "Consumer Goods",
                        //Supervisors = Supervisor.s
                    },
                    new Firm {
                        FirmName = "NCB",
                        FirmDescription = "NCB Capital was launched in 2007 as the investment banking arm of " +
                        "The National Commercial Bank, the largest bank in Saudi Arabia, " +
                        "to provide investment banking services to individual, " +
                        "institutional and corporate clients in the Kingdom.",
                        Address = "Al Shaty, Jeddah 23513 ", 
                        MapLink = "https://goo.gl/maps/Hs5rjJgj6NA2",
                        NumberOfVacencies = 9,
                        IndustryField = "Banking and Finance",
                        //Supervisors = Supervisor
                    },
                    new Firm {
                        FirmName = "Savola Group",
                        FirmDescription = "With 5.34 billion Saudi Riyals and over 30 thousand employees, " +
                        "Savola shined as the biggest investment holding group in the Middle East and North Africa, " +
                        "specialized in foods and retail.",
                        Address = "Prince Faisal Bin Fahd, Ash Shati, Jeddah 23513",
                        MapLink ="https://goo.gl/maps/7FyRoS3NSLw",
                        NumberOfVacencies = 2,
                        IndustryField = "Investment Management",
                    },
                     new Firm {
                        FirmName = "Milk Design Studio",
                        FirmDescription = "Milk is a jeddah-based design studio with a global mindset, local assets. " +
                        "We are focused on brining companies into new challenges to help setting them apart from competitors." +
                        "Milk studio offers a complete repertoire of marketing communication services; branding, retail branding, " +
                        "corporate identity design, naming, stationary, packaging, signage, brochures, posters and websites",
                        Address = "6457 King Abdul Aziz Rd, Al Basatin District, Jeddah 23719",
                        MapLink ="https://goo.gl/maps/b6ys37Jmvnv",
                        NumberOfVacencies = 8,
                        IndustryField = "Design",
                    },
                };

            firms.ForEach(c => context.Firms.AddOrUpdate(m => m.FirmName, c));
            context.SaveChanges();

            // Add examples of internship courses
            var internshipCourses = new List<InternshipCourse>
                {
                    new InternshipCourse {
                        InternshipCourseId = 1,
                        CourseCode = "BBIS 4403",
                        CourseName = "Internship: Business Information System",
                        Description = "Internship course for BIS students.",
                        Credits = 3,
                    },
                    new InternshipCourse {
                        InternshipCourseId = 2,
                        CourseCode = "FINC 4303",
                        CourseName = "Internship: Banking and finance",
                        Description = "Internship course for Banking and finance students.",
                        Credits = 3,
                    },
                    new InternshipCourse {
                        InternshipCourseId = 3,
                        CourseCode = "VLCD 3305",
                        CourseName = "Internship: Visual Communication",
                        Description = "Internship course for graphic and motion graphic students.",
                        Credits = 3,
                    }
                };

            internshipCourses.ForEach(c => context.InternshipCourses.AddOrUpdate(m => m.CourseName, c));
            context.SaveChanges();

            //Add examples of Sections
            var sections = new List<Section>
                {
                      new Section {
                          SectionId = 1,
                          Semester = Semester.SummerI,
                          Year = 2018,
                          Capacity = 20,
                          IntrenshipCourseId = 1,
                      },
                      new Section {
                          SectionId = 2,
                          Semester = Semester.Fall,
                          Year = 2019,
                          Capacity = 20,
                          IntrenshipCourseId = 2,                          
                      },
                      new Section {
                          SectionId = 3,
                          Semester = Semester.Fall,
                          Year = 2019,
                          Capacity = 15,
                          IntrenshipCourseId = 1,
                      },
                      new Section {
                          SectionId = 4,
                          Semester = Semester.Spring,
                          Year = 2019,
                          Capacity = 10,
                          IntrenshipCourseId = 2,
                      }
                };

            sections.ForEach(c => context.Sections.AddOrUpdate(m => m.Semester, c));
            context.SaveChanges();

            // Add examples of students
            var students = new List<Student>
                {
                    new Student {
                        Id = 50,
                        UserName = "amohammed",
                        FirstName = "Abeer",
                        LastName = "Mohammed",
                        StudentUniversityId = "1510987",
                        Email = "amohaammed@dah.edu.sa",
                        Mobile = "0555543444",
                        Department = Department.BusinessAndLaw,
                        Major = "Marketing",
                        SectionId = 1,
                    },
                     new Student {
                        Id = 51,
                        UserName = "hsameh",
                        FirstName = "Hind",
                        LastName = "Sameh",
                        StudentUniversityId = "1610098",
                        Email = "hsameh@dah.edu.sa",
                        Mobile = "0544432345",
                        Department = Department.BusinessAndLaw,
                        Major = "Banking and Finance",
                        SectionId = 2,
                    },
                     new Student {
                        Id = 52,
                        UserName = "dsalama",
                        FirstName = "Doaa",
                        LastName = "Salamah",
                        StudentUniversityId = "1710989",
                        Email = "dsalama@dah.edu.sa",
                        Mobile = "0541231111",
                        Department = Department.BusinessAndLaw,
                        Major = "Human Resources",
                        SectionId = 3,
                    },
                     new Student {
                         Id = 53,
                        UserName = "dzamil",
                        FirstName = "Dina",
                        LastName = "Zamil",
                        StudentUniversityId = "1610009",
                        Email = "dzamil@dah.edu.sa",
                        Mobile = "0556777789",
                        Department = Department.DesignAndArchitecture,
                        Major = "Interior Design",
                        SectionId = 4,
                    },
                };

            string studentPassword = "dahstudent2018";

            foreach (var student in students)
            {
                // Create student user
                if (userManager.FindByName(student.UserName) == null)
                {
                    userManager.Create(student, studentPassword);
                }

                var usertemp = userManager.FindByName(student.UserName);
                if (!userManager.IsInRole(usertemp.Id, roles[2]))
                {
                    userManager.AddToRole(usertemp.Id, roles[2]);
                }
            }

            // Add examples of Supervisors
            var supervisors = new List<Supervisor>
                {
                    new Supervisor {
                        FirstName = "Amal",
                        LastName = "Al-Nahdi",
                        Email = "amal-alnahdi@unilever.com",
                        Phone = "0126789009",
                        Mobile = "0566665678",
                        Department = "Human Resources",
                        FirmId = 1
                    },
                    new Supervisor {
                        FirstName = "Zainab",
                        LastName = "Bin Mahfoz",
                        Email = "Zainabbinmahfoz@ncb.sa",
                        Phone = "0126654321",
                        Mobile = "0554321234",
                        Department = "Human Resources",
                        FirmId = 2
                    },
                     new Supervisor {
                         FirstName = "Ahmad",
                         LastName = "Abdulrahman",
                         Email = "ahmadabdulrahman@savola.com",
                        Phone = "01267890000",
                         Mobile = "0542222212",
                         Department = "Human Resources",
                         FirmId = 3
                     },
                };
            supervisors.ForEach(c => context.Supervisors.AddOrUpdate(m => m.Email, c));
            context.SaveChanges();

            // Add examples of Supervisors
            var visitOnSites = new List<VisitOnSite>
                {
                    new VisitOnSite {
                        VisitDate = new DateTime(2018,3,3),
                        StartTime = new TimeSpan(8,30,0) ,
                        EndTime = new TimeSpan(10,30,0),
                        Feedback = "Discussed student progress"},
                    new VisitOnSite {
                        VisitDate = new DateTime(2018,3,6),
                        StartTime = new TimeSpan(10,0,0) ,
                        EndTime = new TimeSpan(11,30,0),
                        Feedback = "Introduction and dicuss student learning outcome"},
                    new VisitOnSite {
                        VisitDate = new DateTime(2018,3,7),
                        StartTime = new TimeSpan(9,30,0) ,
                        EndTime = new TimeSpan(11,0,0),
                        Feedback = "Checking student positioning and settlment"}
                };
            visitOnSites.ForEach(c => context.VisitOnSites.AddOrUpdate(m => m.VisitDate, c));
            context.SaveChanges();
        }

        /*1
         * The purpose of this rating is: To make the student aware of areas 
         * where improvement is needed and to enable the coordinator to evaluate 
         * the student for academic credit:
            Personal Appearance
            Attendance
            Cooperation
            Sincerity & Dependability
            Interest & Attitude
            Courtesy & Tact
            Self-Confidence
            Enthusiasm
            Judgment 
         *
         * 2
         * What traits of the trainee need improvement?
            Speed & Amount of Work
            Follow Directions
            Getting Along with Other Employees
            Work Without Supervision
            Takes Suggestions
            General Knowledge of Work Procedures
            Accuracy of Work
            Neatness of Work
          * 
          * Other?
          * 
          * 3
          * What work habits or abilities of the trainee needs improvement?
          * 
          * 4
          * In what respect the student shown improvement? 
          * 
          * 5
          * Days absent from work:
          * Reason:
          * 
          * 6
          * Times late for work  
          * Reasons:
          * 
          * 7
          * How does this person compare with other employees added to your staff during this period? (Check one)
                More Capable
                About the Same
                Less Capable
          * 
          * 8
          * At what position level does this student show potential?
          * 
          * 9
          * Confidential remarks and additional comments?
          */
    }
}
