/*      
 *      Description:    This class is the firm model
 *                      firms are institutions or organizations where students apply and attend at for internship
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

        public string Logo { get; set; }

        [StringLength(500)]
        public string FirmDescription { get; set; }

        [StringLength(200)]
        public string MapLink { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }

        public virtual ICollection<Supervisor> Supervisors { get; set; }
    }
}
