/*      
 *      Description:    This class is the supervisor model
 *                      supervisors are employees in different firms where students intern at 
 *                      supervisors are responsibel to supervise students in the firm and train them or assign them to projects
 *                      by the end of the internship period, supervisors need to 
 *                      evaluate the student's performance and growth throughout the internshup period
 *                      they are not part of the university and they cannot access the system 
 *      Author:         Rola Samman
*/

namespace InternshipManagementSystemWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// This is the supervisor model 
    /// Supervisors are employees in different firms
    /// they are responsible of supervising students during their internship
    /// and they to be contacted for internship placement.
    /// </summary>

    [Table("Supervisor")]
    public partial class Supervisor
    {
        public Supervisor()
        {
            Students = new HashSet<Student>();
            SupervisorEvaluations = new HashSet<SupervisorEvaluation>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupervisorId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get { return (FirstName + " " + LastName); } }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        public string Phone { get; set; }

        [Required]
        [StringLength(30)]
        public string Mobile { get; set; }

        [Required]
        [StringLength(80)]
        public string Department { get; set; }

        public int? FirmId { get; set; }

        public virtual Firm Firm { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<SupervisorEvaluation> SupervisorEvaluations { get; set; }
    }
}
