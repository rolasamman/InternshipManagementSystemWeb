using InternshipManagementSystemWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternshipManagementSystemWeb.ViewModels
{
    /// <summary>
    /// Complain view model from the complain model and used by complain controller
    /// The types of the properties should be the same as complain model
    /// Complains are made by students and can be viewd by the admin 
    /// </summary>

    public class ComplainViewModel
    {
        public ComplainViewModel()
        {
        }

        public int ComplainId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(900)]
        public string Description { get; set; }

        public DateTime? CreationDate { get; set; }

        //public int Status { get; set; }

        public ComplainStatus ComplainStatus { get; set; }

        public DateTime? ReplyDate { get; set; }

        [StringLength(900)]
        public string Feedback { get; set; }

        public int? AdminId { get; set; }

        public int? StudentId { get; set; }

        public virtual Admin Admin { get; set; }

        public virtual Student Student { get; set; }
    }
    public enum ComplainStatus
    {
        //[Display(Name = "Attribute")],
        Open, Closed
    }
}