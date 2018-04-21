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
using System.Linq;
using System.Web;

namespace InternshipManagementSystemWeb.ViewModels
{
    /// <summary>
    /// Supervisor evaluation view model from the supervisor evalutation model and used by supervisor evalutation controller
    /// The types of the properties should be the same as supervisor evalutation model
    /// Supervisor evaluation is to be completed by supervisors at the end of the internship period 
    /// supervisor evaluate students and their performance
    /// </summary>

    public class SupervisorEvaluationViewModel
    {
        public SupervisorEvaluationViewModel()
        {
        }

        public int SupervisorEvaluationId { get; set; }

        public DateTime EvaluationDate { get; set; }

        public int? StudentId { get; set; }

        public int? SupervisorId { get; set; }

        public virtual Student Student { get; set; }

        public virtual Supervisor Supervisor { get; set; }

        //public virtual ICollection<SupervisorCriterion> SupervisorCriterions { get; set; }
        // List of SupervisorCriterions in this evaluation
        public List<SupervisorCriterion> SupervisorCriterions { get; set; }
    }
}