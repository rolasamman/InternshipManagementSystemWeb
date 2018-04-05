/*      
 *      Description:    This class is the internship evaluation model
 *                      by the end of the internship period students need to evalate their work experience and work surpervisors
 *      Author:         Rola Samman
*/

namespace InternshipManagementSystemWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InternshipEvaluation")]
    public partial class InternshipEvaluation
    {
        public InternshipEvaluation()
        {
            InternshipCriterions = new HashSet<InternshipCriterion>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InternshipEvaluationId { get; set; }

        public DateTime EvaluationDate { get; set; }

        public int? StudentId { get; set; }

        public int? SectionId { get; set; }

        public virtual ICollection<InternshipCriterion> InternshipCriterions { get; set; }

        public virtual Section Section { get; set; }

        public virtual Student Student { get; set; }
    }
}
