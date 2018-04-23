/*    
 *      Description:    This is an Internship Management System for a university. 
 *                      The project handles internship matters of the internship department of the university. 
 *                      The aim of the project is to make communications between users most efficient and effective. 
 *                      It also provides users with necessary data and records needed information.
 *      
 *      Author:         Rola Samman
*/

using AutoMapper;
using InternshipManagementSystemWeb.Models;
using InternshipManagementSystemWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternshipManagementSystemWeb.Controllers
{
    [Authorize]
    public class MeetingOnCampusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MeetingOnCampus
        [Authorize(Roles = "Admin, Instructor, Student")]
        public ActionResult Index()
        {
            var eetingOnCampus = db.MeetingOnCampuse.ToList();
            var model = new List<MeetingOnCampusViewModel>();
            foreach (var item in meetingOnCampus)
            {
                model.Add(new MeetingOnCampusViewModel
                {
                    AttendanceId = item.AttendanceId,
                    AttendanceDate = item.AttendanceDate,
                    TimeIn = item.TimeIn,
                    TimeOut = item.TimeOut,
                    Description = item.Description
                });
            }
            return View(model);
        }

        // GET: MeetingOnCampus/Details/5
        [Authorize(Roles = "Admin, Instructor, Student")]
        public ActionResult Details(int? id)
        {
            MeetingOnCampus meetingOnCampus = db.MeetingOnCampus.Find(id);
            MeetingOnCampusViewModel model = Mapper.Map<MeetingOnCampus, MeetingOnCampusViewModel>(meetingOnCampus);
            return View(model);
        }
            // GET: MeetingOnCampus/Create
            public ActionResult Create()
        {
            return View();
        }

        // POST: MeetingOnCampus/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MeetingOnCampus/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MeetingOnCampus/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MeetingOnCampus/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MeetingOnCampus/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
