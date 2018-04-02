using InternshipManagementSystemWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternshipManagementSystemWeb.ViewModels
{
    /// <summary>
    /// Internship criterion view model from the internship criterion model and used by internship criterion controller
    /// The types of the properties should be the same as internship criterion model
    /// Internship criterion is what the student evaluation is based on
    /// </summary>

    public class InternshipCriterionViewModel
    {
        public InternshipCriterionViewModel()
        {
        }
        public int InternshipCriterionId { get; set; }

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
        public int InternshipEvaluationId { get; set; }

        public virtual InternshipEvaluation InternshipEvaluation { get; set; }
    }
}