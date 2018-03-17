namespace InternshipManagementSystemWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VisitOnSite")]
    public partial class VisitOnSite
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VisitOnSiteId { get; set; }

        [Column(TypeName = "date")]
        public DateTime VisitDate { get; set; }

        [Required]
        [StringLength(900)]
        public string Feedback { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int? InstructorId { get; set; }

        public int? StudentId { get; set; }

        public virtual Instructor Instructor { get; set; }

        public virtual Student Student { get; set; }
    }
}
