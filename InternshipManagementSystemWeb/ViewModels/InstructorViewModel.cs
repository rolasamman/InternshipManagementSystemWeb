using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternshipManagementSystemWeb.ViewModels
{
    /// <summary>
    /// Instructor view model from the instructor model and used by instructor controller
    /// The types of the properties should be the same as instructor model
    /// Instructors are responsible of the internship course and students registered
    /// </summary>

    public class InstructorViewModel
    {
        public InstructorViewModel()
        {
        }
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Employee ID")]
        public string EmployeeUniversityId { get; set; }

        public string Office { get; set; }

        public string Phone { get; set; }

        public string Extension { get; set; }

        public string Mobile { get; set; }

        //[Required]
        //[StringLength(50)]
        //public string Department { get; set; }

        public Department Department { get; set; }
    }
    public enum Department
    {
        BusinessAndLaw, DesignAndArchitecture, EducationAndHealthScience
    }
}