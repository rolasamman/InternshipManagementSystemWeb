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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SupervisorEvaluation()
        {
            SupervisorCriterions = new HashSet<SupervisorCriterion>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupervisorEvaluationId { get; set; }

        public DateTime EvaluationDate { get; set; }

        public int? StudentId { get; set; }

        public int? SupervisorId { get; set; }

        public virtual Student Student { get; set; }

        public virtual Supervisor Supervisor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupervisorCriterion> SupervisorCriterions { get; set; }
    }
}
