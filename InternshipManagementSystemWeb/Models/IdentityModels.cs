using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InternshipManagementSystemWeb.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser <int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Complain> Complains { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Firm> Firms { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<InternshipCourse> InternshipCourses { get; set; }
        public virtual DbSet<InternshipCriterion> InternshipCriterions { get; set; }
        public virtual DbSet<InternshipEvaluation> InternshipEvaluations { get; set; }
        public virtual DbSet<MeetingOnCampu> MeetingOnCampus { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Supervisor> Supervisors { get; set; }
        public virtual DbSet<SupervisorCriterion> SupervisorCriterions { get; set; }
        public virtual DbSet<SupervisorEvaluation> SupervisorEvaluations { get; set; }
        public virtual DbSet<VisitOnSite> VisitOnSites { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Employee>()
            //    .HasOptional(e => e.Admin)
            //    .WithRequired(e => e.Employee);

            //modelBuilder.Entity<Employee>()
            //    .HasOptional(e => e.Instructor)
            //    .WithRequired(e => e.Employee);

            modelBuilder.Entity<InternshipCourse>()
                .HasMany(e => e.Sections)
                .WithOptional(e => e.InternshipCourse)
                .HasForeignKey(e => e.IntrenshipCourseId);

            modelBuilder.Entity<InternshipEvaluation>()
                .HasMany(e => e.InternshipCriterions)
                .WithRequired(e => e.InternshipEvaluation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SupervisorEvaluation>()
                .HasMany(e => e.SupervisorCriterions)
                .WithRequired(e => e.SupervisorEvaluation)
                .WillCascadeOnDelete(false);
        }
    }

    public class CustomUserRole : IdentityUserRole<int> { }
    public class CustomUserClaim : IdentityUserClaim<int> { }
    public class CustomUserLogin : IdentityUserLogin<int> { }

    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }

    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, int,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}