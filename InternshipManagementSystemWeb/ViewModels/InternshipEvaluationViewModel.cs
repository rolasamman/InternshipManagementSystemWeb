using InternshipManagementSystemWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternshipManagementSystemWeb.ViewModels
{
    /// <summary>
    /// Internship evaluation view model from the internship evalutation model and used by internship evalutation controller
    /// The types of the properties should be the same as internship evalutation model
    /// Internship evaluation is to be completed by students at the end of their internship period 
    /// Students evaluate their internship experience, their instructor, their supervisor, and their learning outcomes
    /// </summary>

    public class InternshipEvaluationViewModel
    {
        public InternshipEvaluationViewModel()
        {
        }

        public int InternshipEvaluationId { get; set; }

        public DateTime EvaluationDate { get; set; }

        public int? StudentId { get; set; }

        public int? SectionId { get; set; }

        public virtual ICollection<InternshipCriterion> InternshipCriterions { get; set; }

        public virtual Section Section { get; set; }

        public virtual Student Student { get; set; }
    }
}