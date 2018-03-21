﻿using InternshipManagementSystemWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternshipManagementSystemWeb.ViewModels
{
    public class SupervisorViewModel
    {
        public SupervisorViewModel()
        {
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupervisorId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        public string Phone { get; set; }

        [Required]
        [StringLength(30)]
        public string Mobile { get; set; }

        [Required]
        [StringLength(80)]
        public string Department { get; set; }

        public int? FirmId { get; set; }

        public virtual Firm Firm { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<SupervisorEvaluation> SupervisorEvaluations { get; set; }
    }
}