using InternshipManagementSystemWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternshipManagementSystemWeb.ViewModels
{
    /// <summary>
    /// Supervisor criterion view model from the supervisor criterion model and used by supervisor criterion controller
    /// The types of the properties should be the same as supervisor criterion model
    /// Supervisor criterion is what the supervisor evaluation is based on
    /// </summary>

    public class SupervisorCriterionViewModel
    {
        public SupervisorCriterionViewModel()
        {
        }

        public int SupervisorCriterionId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Grade { get; set; }

        [StringLength(200)]
        public string Comment { get; set; }

        [Key]
        //[Column(Order = 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupervisorEvaluationId { get; set; }

        public virtual SupervisorEvaluation SupervisorEvaluation { get; set; }

    }
}