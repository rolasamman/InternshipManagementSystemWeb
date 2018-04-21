/*    
 *      Description:    This is an Internship Management System for a university. 
 *                      The project handles internship matters of the internship department of the university. 
 *                      The aim of the project is to make communications between users most efficient and effective. 
 *                      It also provides users with necessary data and records needed information.
 *      
 *      Author:         Rola Samman
*/

using InternshipManagementSystemWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InternshipManagementSystemWeb.ViewModels
{
    /// <summary>
    /// This is supervisor view model from the supervisor model and used by the supervisor controller
    /// The types of the properties should be the same as Supervisor model
    /// Especialy nullable and non-nullable properties
    /// Supervisors are employees in different firms
    /// they are responsible of supervising students during their internship
    /// and they to be contacted for internship placement
    /// </summary>

    public class SupervisorViewModel
    {
        public SupervisorViewModel()
        {
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupervisorId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name = "Name")]
        public string FullName { get { return (FirstName + " " + LastName); } }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        public string Phone { get; set; }

        [Required]
        [StringLength(30)]
        public string Mobile { get; set; }

        [Required]
        [StringLength(80)]
        public string Department { get; set; }

        public int? FirmId { get; set; }

        public virtual Firm Firm { get; set; }

        //public virtual ICollection<Student> Students { get; set; }
        // List of students work with the supervisor
        public List<Student> students { get; set; }

        //public virtual ICollection<SupervisorEvaluation> SupervisorEvaluations { get; set; }
        // List of evaluations of this supervisor
        public List<SupervisorEvaluation> SupervisorEvaluations { get; set; }
    }
}