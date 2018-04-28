using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InternshipManagementSystemWeb.Models
{
    public class InternshipForm
    {
        public int InternshipFormId { get; set; }

        [StringLength(200)]
        public string InternshipAgreementForm { get; set; }

        [StringLength(200)]
        public string RiskIdentificationForm { get; set; }

        [StringLength(200)]
        public string InternshipBooklet { get; set; }
    }
}