/*      
 *      Description:    This class is the student model
 *                      students enrolled in the university and registered in the internship course
 *      Author:         Rola Samman
*/

namespace InternshipManagementSystemWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student : ApplicationUser
    {
        public Student()
        {
            Attendances = new HashSet<Attendance>();
            Complains = new HashSet<Complain>();
            InternshipEvaluations = new HashSet<InternshipEvaluation>();
            MeetingOnCampus = new HashSet<MeetingOnCampu>();
            SupervisorEvaluations = new HashSet<SupervisorEvaluation>();
            VisitOnSites = new HashSet<VisitOnSite>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int StudentId { get; set; }

        //[Required]
        //[StringLength(256)]
        //public string UserName { get; set; }

        [Required]
        [StringLength(10)]
        public string StudentUniversityId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        //[Required]
        //[StringLength(50)]
        //public string Department { get; set; }

        public Department Department { get; set; }

        [Required]
        [StringLength(50)]
        public string Major { get; set; }

        //[Required]
        //[StringLength(100)]
        //public string Email { get; set; }

        [Required]
        [StringLength(30)]
        public string Mobile { get; set; }

        //[Required]
        //[StringLength(100)]
        //public string Password { get; set; }

        [StringLength(200)]
        public string Resume { get; set; } 

        [StringLength(200)]
        public string InternshipAgreementForm { get; set; }

        [StringLength(200)]
        public string RiskIdentificationForm { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public int? SectionId { get; set; }

        public int? SupervisorId { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }

        public virtual ICollection<Complain> Complains { get; set; }

        public virtual ICollection<InternshipEvaluation> InternshipEvaluations { get; set; }

        public virtual ICollection<MeetingOnCampu> MeetingOnCampus { get; set; }

        public virtual Section Section { get; set; }

        public virtual Supervisor Supervisor { get; set; }

        public virtual ICollection<SupervisorEvaluation> SupervisorEvaluations { get; set; }

        public virtual ICollection<VisitOnSite> VisitOnSites { get; set; }

    }
}
