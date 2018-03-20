using InternshipManagementSystemWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternshipManagementSystemWeb.ViewModels
{
    public class AnnouncementViewModel
    {
        public AnnouncementViewModel()
        {
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AnnouncementId { get; set; }

        [Required]
        [StringLength(100)]
        public string Subject { get; set; }

        public DateTime AnnouncementDate { get; set; }

        [Required]
        [StringLength(900)]
        public string Description { get; set; }

        public int? AdminId { get; set; }

        public virtual Admin Admin { get; set; }
    }
}