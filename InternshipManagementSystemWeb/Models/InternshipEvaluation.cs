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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InternshipEvaluation()
        {
            InternshipCriterions = new HashSet<InternshipCriterion>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InternshipEvaluationId { get; set; }

        public DateTime EvaluationDate { get; set; }

        public int? StudentId { get; set; }

        public int? SectionId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InternshipCriterion> InternshipCriterions { get; set; }

        public virtual Section Section { get; set; }

        public virtual Student Student { get; set; }
    }
}
