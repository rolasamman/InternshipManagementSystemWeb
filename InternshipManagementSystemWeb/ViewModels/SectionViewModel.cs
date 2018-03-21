using InternshipManagementSystemWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternshipManagementSystemWeb.ViewModels
{
    public class SectionViewModel
    {
        public SectionViewModel()
        {
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SectionId { get; set; }

        //public int Semester { get; set; }
        //Create a name for the type (Semester). Also put a name for the attribute (Semester).
        public Semester Semester { get; set; }

        public int Year { get; set; }

        public int Capacity { get; set; }

        public int? IntrenshipCourseId { get; set; }

        public int? InstructorId { get; set; }

        public virtual Instructor Instructor { get; set; }

        public virtual InternshipCourse InternshipCourse { get; set; }

        //public virtual ICollection<InternshipEvaluation> InternshipEvaluations { get; set; }
        // List of evaluations in this section
        public List<InternshipEvaluation> InternshipEvaluations { get; set; }

        //public virtual ICollection<Student> Students { get; set; }
        // List of students in this section
        public List<Student> Students { get; set; }
    }

    public enum Semester
    {
        //[Display(Name = "Attribute")],
        Fall, Spring, SummerI, SummernII
    }
}