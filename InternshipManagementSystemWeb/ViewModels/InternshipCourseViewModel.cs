using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static System.Collections.Specialized.BitVector32;

namespace InternshipManagementSystemWeb.ViewModels
{
    public class InternshipCourseViewModel
    {
        public InternshipCourseViewModel()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InternshipCourseId { get; set; }

        [Required]
        [StringLength(100)]
        public string CourseName { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public int Credits { get; set; }

        public virtual ICollection<Section> Sections { get; set; }

    }
}