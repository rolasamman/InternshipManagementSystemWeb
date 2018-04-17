using InternshipManagementSystemWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternshipManagementSystemWeb.ViewModels
{
    /// <summary>
    /// This is frim view model from the firm model and used by the firm controller
    /// The types of the properties should be the same as firm model
    /// Firms are companies or organizations where students can do their internship at
    /// </summary>

    public class FirmViewModel
    {
        public FirmViewModel()
        {
        }

        public int FirmId { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name = "Name")]
        public string FirmName { get; set; }

        [Required]
        [StringLength(2000)]
        public string Address { get; set; }

        [Display(Name = "Number of vacencies")]
        public int NumberOfVacencies { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name = "Industry Field")]
        public string IndustryField { get; set; }

        // The outline file as object (used to upload a file)
        [Display(Name = "Logo")]
        public HttpPostedFileBase LogoImage { get; set; }

        // The outline file path as string (used to display the path)
        public string Logo { get; set; }

        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "About the Company")]
        public string FirmDescription { get; set; }

        [StringLength(200)]
        [Display(Name = "Map Link")]
        public string MapLink { get; set; }

        // List of supervisors in this firm
        public List<Supervisor> Supervisors { get; set; }
       
       

    }
}