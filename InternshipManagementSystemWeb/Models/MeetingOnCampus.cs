/*      
 *      Description:    This class is the meeting on campus model
 *                      during the internship instructors meet with their students 
 *                      to discuss the students progress in the internship
 *      Author:         Rola Samman
*/

namespace InternshipManagementSystemWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MeetingOnCampus
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MeetingOnCampusId { get; set; }

        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime MeetingDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        [Required]
        [StringLength(900)]
        public string Feedback { get; set; }

        public int? InstructorId { get; set; }

        public int? StudentId { get; set; }

        public virtual Instructor Instructor { get; set; }

        public virtual Student Student { get; set; }
    }
}
