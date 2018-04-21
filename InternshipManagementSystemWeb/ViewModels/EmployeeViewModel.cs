/*    
 *      Description:    This is an Internship Management System for a university. 
 *                      The project handles internship matters of the internship department of the university. 
 *                      The aim of the project is to make communications between users most efficient and effective. 
 *                      It also provides users with necessary data and records needed information.
 *      
 *      Author:         Rola Samman
*/

using InternshipManagementSystemWeb.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternshipManagementSystemWeb.ViewModels
{
    /// <summary>
    /// Employee view model from the Employee model and used by Employee controller
    /// The types of the properties should be the same as Employee model
    /// Especialy nullable and non-nullable properties
    /// Employees can bee admin and instructor
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

        [NotMapped]
        [Display(Name = "Name")]
        public string FullName { get { return (FirstName + " " + LastName); } }

        [Required]
        [StringLength(10)]
        [Display(Name = "Employee ID")]
        public string EmployeeUniversityId { get; set; }
        
        public string Office { get; set; }

        public string Phone { get; set; }

        public string Extension { get; set; }

        [Required]
        [StringLength(20)]
        public string Mobile { get; set; }

        public string Roles { get; set; }
    }
}