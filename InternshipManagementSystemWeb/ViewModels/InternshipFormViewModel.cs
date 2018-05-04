using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternshipManagementSystemWeb.ViewModels
{
    public class InternshipFormViewModel
    {
        public InternshipFormViewModel()
        {
        }

        public int InternshipFormId { get; set; }

        [Required] 
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        [Display(Name = "Form Path")]
        public string FormPath { get; set; }

        // Used to upload a file
        [Display(Name = "Form Upload")]
        public HttpPostedFileBase FormUpload { get; set; }
    }
}