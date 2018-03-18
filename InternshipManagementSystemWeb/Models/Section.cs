namespace InternshipManagementSystemWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Section")]
    public partial class Section
    {
        public Section()
        {
            InternshipEvaluations = new HashSet<InternshipEvaluation>();
            Students = new HashSet<Student>();
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

        public virtual ICollection<InternshipEvaluation> InternshipEvaluations { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }

    public enum Semester
    {
        //[Display(Name = "Attribute")],
        Fall, Spring, SummerI, SummernII
    }
}
