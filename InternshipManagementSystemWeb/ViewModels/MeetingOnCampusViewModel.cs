﻿using InternshipManagementSystemWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternshipManagementSystemWeb.ViewModels
{
    /// <summary>
    /// Meeting on campus view model from the meeting on campus model and used by meeting on campus controller
    /// The types of the properties should be the same as meeting on campus model
    /// Meeting on campus is the record of the instructors meetings with students regarding the internship course
    /// The instructors log the meeting for each student
    /// </summary>

    public class MeetingOnCampusViewModel
    {
        public MeetingOnCampusViewModel()
        {
        }

        public int MeetingOnCampusId { get; set; }

        //[Column(TypeName = "date")]
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