/*      
 *      Description:    This class is the supervisor evalutaion model                     
 *                      as they are not part of the university and they cannot access the system by the end 
 *                      of the internship period, an evaluation link is to be sent to the supervisor
 *                      then the supervisor have to evaluate students
 *      Author:         Rola Samman
*/

namespace InternshipManagementSystemWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SupervisorEvaluation")]
    public partial class SupervisorEvaluation
    {
        public SupervisorEvaluation()
        {
            SupervisorCriterions = new HashSet<SupervisorCriterion>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupervisorEvaluationId { get; set; }

        public DateTime EvaluationDate { get; set; }

        public int? StudentId { get; set; }

        public int? SupervisorId { get; set; }

        public virtual Student Student { get; set; }

        public virtual Supervisor Supervisor { get; set; }

        public virtual ICollection<SupervisorCriterion> SupervisorCriterions { get; set; }
    }
}
