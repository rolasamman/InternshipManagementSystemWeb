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
    /// Especialy nullable and non-nullable properties
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
        public string IndustryField { get; set; }
    }
}