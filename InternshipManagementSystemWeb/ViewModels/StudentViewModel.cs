using InternshipManagementSystemWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace InternshipManagementSystemWeb.ViewModels
{
    /// <summary>
    /// Student view model from the student model and used by student controller
    /// The types of the properties should be the same as admin model
    /// Especialy nullable and non-nullable properties
    /// </summary>
    public class StudentViewModel
    {
        public StudentViewModel()
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
        [Display(Name = "Student ID")]
        public string StudentUniversityId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Department")]
        public string Department { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Major")]
        public string Major { get; set; }

    }
}
