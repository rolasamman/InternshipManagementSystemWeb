/*      
 *      Description:    This class is the supervisor criterion model
 *                      by the end of the internship period, an evaluation link is to be sent to the supervisor
 *                      supervisor criterion model is about the criteria supervisors need to follow to evaluate students
 *      Author:         Rola Samman
*/

namespace InternshipManagementSystemWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SupervisorCriterion")]
    public partial class SupervisorCriterion
    {
        [Key]
        [Column(Order = 0)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupervisorCriterionId { get; set; }

        [Required]
        [StringLength(100)]
        public string Question { get; set; }

        [Required]
        [StringLength(50)]
        public string Grade { get; set; }

        [StringLength(200)]
        public string Comment { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupervisorEvaluationId { get; set; }

        public virtual SupervisorEvaluation SupervisorEvaluation { get; set; }
    }
}
