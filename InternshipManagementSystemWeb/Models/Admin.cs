/*      
 *      Description:    This class is the admins model
 *                      the admin is an employee from the internship department 
 *                      her responsibility is to manage and coordinate internship matters
 *      Author:         Rola Samman
*/

namespace InternshipManagementSystemWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin : Employee
    {
        public Admin()
        {
            Announcements = new HashSet<Announcement>();
            Complains = new HashSet<Complain>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int AdminId { get; set; }

        //public virtual Employee Employee { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }

        public virtual ICollection<Complain> Complains { get; set; }
    }
}
