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

        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime AttendanceDate { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        [Display(Name = "Time In")]
        public TimeSpan TimeIn { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:t}", ApplyFormatInEditMode = true)]
        [Display(Name = "Time Out")]
        public TimeSpan TimeOut { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(900)]
        public string Description { get; set; }

        public int? StudentId { get; set; }

        public int? FirmId { get; set; }

        public virtual Firm Firm { get; set; }

        public virtual Student Student { get; set; }

        [StringLength(200)]
        public string ApprovedAttendance { get; set; }

        [Display(Name = "Approved Attendance")]
        public HttpPostedFileBase ApprovedAttendanceFile { get; set; }
    }
}