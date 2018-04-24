/*      
 *      Description:    This class is the internship criterion model
 *                      internship criterion creates the criteria used for evalating the internship course by the students
 *      Author:         Rola Samman
*/

namespace InternshipManagementSystemWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InternshipCriterion")]
    public partial class InternshipCriterion
    {
        [Key]
        [Column(Order = 0)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InternshipCriterionId { get; set; }

        [Required]
        [StringLength(100)]
        public string Question { get; set; }

        [Required]
        [StringLength(50)]
        public string Grade { get; set; }

        [StringLength(200)]
        public string Comment { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InternshipEvaluationId { get; set; }

        public virtual InternshipEvaluation InternshipEvaluation { get; set; }
    }
}
