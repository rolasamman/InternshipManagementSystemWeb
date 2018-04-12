/*      
 *      Description:    This class is the instructor model 
 *                      instructors are emloyees of the university 
 *                      they responsible for students and supervise their progress in the internship in the university
 *      Author:         Rola Samman
*/

namespace InternshipManagementSystemWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Instructor")]
    public partial class Instructor : Employee
    {
        public Instructor()
        {
            MeetingOnCampus = new HashSet<MeetingOnCampu>();
            Sections = new HashSet<Section>();
            VisitOnSites = new HashSet<VisitOnSite>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int InstructorId { get; set; }

        //public virtual Employee Employee { get; set; }

        public virtual ICollection<MeetingOnCampu> MeetingOnCampus { get; set; }

        public virtual ICollection<Section> Sections { get; set; }

        public virtual ICollection<VisitOnSite> VisitOnSites { get; set; }

        [Required]
        [StringLength(50)]
        public string Department { get; set; }

        //    public Department Department { get; set; }
    }
    //public enum Department
    //{
    //    //[Display(Name = "Attribute")],
    //    BusinessAndLaw, DesignAndArcheticture, HelthScienceandLearning
    //}
}
