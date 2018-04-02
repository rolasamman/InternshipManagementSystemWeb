using InternshipManagementSystemWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternshipManagementSystemWeb.ViewModels
{
    /// <summary>
    /// Visit On Site view model from the visit on site model and used by visit on site controller
    /// The types of the properties should be the same as visit on site model
    /// Instructors log their visits to firms of the internship students 
    /// </summary>

    public class VisitOnSiteViewModel
    {
        VisitOnSiteViewModel()
        {
        }
        public int VisitOnSiteId { get; set; }

        //[Column(TypeName = "date")]
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