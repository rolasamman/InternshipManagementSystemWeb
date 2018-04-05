/*      
 *      Description:    This class is the internship course model
 *                      the internship course is the course dedicated for internship 
 *                      students register in the course and instructors assigned to courses
 *      Author:         Rola Samman
*/

namespace InternshipManagementSystemWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InternshipCourse")]
    public partial class InternshipCourse
    {
        public InternshipCourse()
        {
            Sections = new HashSet<Section>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InternshipCourseId { get; set; }

        [Required]
        [StringLength(10)]
        public string CourseCode { get; set; }

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
