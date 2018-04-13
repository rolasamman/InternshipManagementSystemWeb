using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static System.Collections.Specialized.BitVector32;

namespace InternshipManagementSystemWeb.ViewModels
{
    /// <summary>
    /// Internship Course view model from the Internship Course model and used by Internship Course controller
    /// The types of the properties should be the same as Internship Course model
    /// Internship couse is the course that students need to be registered at in order to complete the internship requirements
    /// </summary>

    public class InternshipCourseViewModel
    {
        public InternshipCourseViewModel()
        {
        }

        public int InternshipCourseId { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required]
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int Credits { get; set; }

        //public virtual ICollection<Section> Sections { get; set; }
        // List of sections in this course
        public List<Section> Sections { get; set; }
    }
}