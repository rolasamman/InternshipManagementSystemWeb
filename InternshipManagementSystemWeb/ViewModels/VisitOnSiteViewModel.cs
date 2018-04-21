/*    
 *      Description:    This is an Internship Management System for a university. 
 *                      The project handles internship matters of the internship department of the university. 
 *                      The aim of the project is to make communications between users most efficient and effective. 
 *                      It also provides users with necessary data and records needed information.
 *      
 *      Author:         Rola Samman
*/

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
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
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