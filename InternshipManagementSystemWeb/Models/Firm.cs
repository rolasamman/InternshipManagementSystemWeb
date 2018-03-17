namespace InternshipManagementSystemWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Firm")]
    public partial class Firm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Firm()
        {
            Attendances = new HashSet<Attendance>();
            Supervisors = new HashSet<Supervisor>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attendance> Attendances { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supervisor> Supervisors { get; set; }
    }
}
