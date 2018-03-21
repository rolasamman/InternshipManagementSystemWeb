namespace InternshipManagementSystemWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// This is the firm model
    /// Firms are companies or organizations where students can do their internship at
    /// </summary>

    [Table("Firm")]
    public partial class Firm
    {
        public Firm()
        {
            Attendances = new HashSet<Attendance>();
            Supervisors = new HashSet<Supervisor>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FirmId { get; set; }

        [Required]
        [StringLength(80)]
        public string FirmName { get; set; }

        [Required]
        [StringLength(2000)]
        public string Address { get; set; }

        public int NumberOfVacencies { get; set; }

        [Required]
        [StringLength(80)]
        public string IndustryField { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }

        public virtual ICollection<Supervisor> Supervisors { get; set; }
    }
}
