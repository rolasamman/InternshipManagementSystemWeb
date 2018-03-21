using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternshipManagementSystemWeb.ViewModels
{
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

        public int NumberOfVacencies { get; set; }

        [Required]
        [StringLength(80)]
        public string IndustryField { get; set; }
    }
}