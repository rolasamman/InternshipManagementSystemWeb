/*      Description: This is the employee view model 
 *      Author: Rola Samman
 */

using InternshipManagementSystemWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace InternshipManagementSystemWeb.ViewModels
{
    /// <summary>
    /// Student view model from the Employee model and used by Employee controller
    /// The types of the properties should be the same as Employee model
    /// Especialy nullable and non-nullable properties
    /// </summary>
    
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
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

        public string Roles { get; set; }

    }
}