/*    
 *      Description:    This is an Internship Management System for a university. 
 *                      The project handles internship matters of the internship department of the university. 
 *                      The aim of the project is to make communications between users most efficient and effective. 
 *                      It also provides users with necessary data and records needed information.
 *      
 *      Author:         Rola Samman
*/

using InternshipManagementSystemWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternshipManagementSystemWeb.ViewModels
{
    public class SectionViewModel
    {
        /// <summary>
        /// Section view model from the section model and used by section controller
        /// The types of the properties should be the same as section model
        /// Sections are part of internship course, a course may have more than one section
        /// A section is a collection of students 
        /// </summary>

        public SectionViewModel()
        {
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SectionId { get; set; }

        public string SectionNumber { get; set; }

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