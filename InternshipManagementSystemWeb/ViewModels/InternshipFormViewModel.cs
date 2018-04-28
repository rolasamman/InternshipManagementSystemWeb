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

        //[StringLength(200)]
        //public string InternshipAgreementForm { get; set; }

        //[StringLength(200)]
        //public string RiskIdentificationForm { get; set; }

        //[StringLength(200)]
        //public string InternshipBooklet { get; set; }


        // The outline file as object (used to upload a file)
        [Display(Name = "Internship  Agreement Form")]
        public HttpPostedFileBase InternshipAgreementFormUpload { get; set; }

        // The outline file path as string (used to display the path)
        [Display(Name = "Internship  Agreement Form")]
        public string InternshipAgreementForm { get; set; }

        // The outline file as object (used to upload a file)
        [Display(Name = "Risk Identification Form")]
        public HttpPostedFileBase RiskIdentificationFormUpload { get; set; }

        // The outline file path as string (used to display the path)
        [Display(Name = "Risk Identification Form")]
        public string RiskIdentificationForm { get; set; }

        // The outline file as object (used to upload a file)
        [Display(Name = "Internship Booklet")]
        public HttpPostedFileBase InternshipBookletUpload { get; set; }

        // The outline file path as string (used to display the path)
        [Display(Name = "Internship Booklet")]
        public string InternshipBooklet { get; set; }
    }
}