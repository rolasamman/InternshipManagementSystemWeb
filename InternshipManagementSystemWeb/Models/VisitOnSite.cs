/*      
 *      Description:    This class is the visit on site model                     
 *                      instructors need to visit students and their firm supervisor and document their visit 
 *      Author:         Rola Samman
*/

namespace InternshipManagementSystemWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VisitOnSite")]
    public partial class VisitOnSite
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VisitOnSiteId { get; set; }

        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime VisitDate { get; set; }

        [Required]
        [StringLength(900)]
        public string Feedback { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int? InstructorId { get; set; }

        public int? StudentId { get; set; }

        public virtual Instructor Instructor { get; set; }

        public virtual Student Student { get; set; }
    }
}
