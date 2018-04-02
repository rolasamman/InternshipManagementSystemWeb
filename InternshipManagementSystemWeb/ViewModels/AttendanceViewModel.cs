using InternshipManagementSystemWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternshipManagementSystemWeb.ViewModels
{
    /// <summary>
    /// Attendance view model from the attendance model and used by attendance controller
    /// The types of the properties should be the same as attendance model
    /// Attendance is for students attendance in the internship course at a specific firm
    /// </summary>

    public class AttendanceViewModel
    {
        public AttendanceViewModel()
        {
        }

        public int AttendanceId { get; set; }

        //[Column(TypeName = "date")]
        [Display(Name = "Date")]
        public DateTime AttendanceDate { get; set; }

        public TimeSpan TimeIn { get; set; }

        public TimeSpan TimeOut { get; set; }

        [Required]
        [StringLength(900)]
        public string Description { get; set; }

        public int? StudentId { get; set; }

        public int? FirmId { get; set; }

        public virtual Firm Firm { get; set; }

        public virtual Student Student { get; set; }
    }
}