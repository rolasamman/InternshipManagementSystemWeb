using InternshipManagementSystemWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternshipManagementSystemWeb.ViewModels
{
    /// <summary>
    /// Announcement view model from the announcement model and used by announcement controller
    /// The types of the properties should be the same as announcement model
    /// Announcements can be made by the admin only 
    /// Announcements cn be viewed by students and instructors
    /// </summary>

    public class AnnouncementViewModel
    {
        public AnnouncementViewModel()
        {
        }

        public int AnnouncementId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Title")]
        public string Subject { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? AnnouncementDate { get; set; }

        [Required]
        [StringLength(900)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        //public int? AdminId { get; set; }

        //public virtual Admin Admin { get; set; }
    }
}