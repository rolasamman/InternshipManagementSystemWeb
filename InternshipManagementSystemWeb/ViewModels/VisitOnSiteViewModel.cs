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
        public VisitOnSiteViewModel()
        {
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VisitOnSiteId { get; set; }

        //[Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of visit")]
        public DateTime VisitDate { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(900)]
        public string Feedback { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time")]
        public TimeSpan StartTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Time")]
        public TimeSpan EndTime { get; set; }

        public int? InstructorId { get; set; }

        public int? StudentId { get; set; }

        public virtual Instructor Instructor { get; set; }

        public virtual Student Student { get; set; }
    }
}