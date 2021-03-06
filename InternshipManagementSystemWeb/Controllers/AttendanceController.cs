﻿/*    
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
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace InternshipManagementSystemWeb.Controllers
{
    /// <summary>
    /// Announcement controller manages attendances 
    /// This controller uses attendance model and attendance viewModel
    /// </summary>

    public class AttendanceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // The index action allow displaying and listing the items that are in the attendance table/model
        // GET: Attendance
        [Authorize(Roles = "Admin, Instructor, Student")]
        public ActionResult Index()
        {   
            var loginId = User.Identity.GetUserId<int>();
            var attendances = db.Attendances.Where(x => x.StudentId == loginId).ToList();
            var model = new List<AttendanceViewModel>();

            foreach (var item in attendances)
            {
                model.Add(new AttendanceViewModel
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

        // The details action allow displaying the details of a selected item by Id in the attendance table/model 
        // GET: Attendance/Details/5
        [Authorize(Roles = "Admin, Instructor, Student")]
        public ActionResult Details(int? id)
        {
            Attendance attendance = db.Attendances.Find(id);
            AttendanceViewModel model = Mapper.Map<Attendance, AttendanceViewModel>(attendance);
            return View(model);
        }

        // GET: Attendance/Create
        [Authorize(Roles = "Student")]
        public ActionResult Create()
        {
            return View();
        }

        // The create action allows adding a new item to the attendance table/model
        // POST: Attendance/Create
        [Authorize(Roles = "Student")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AttendanceViewModel model)
        {
            if (ModelState.IsValid)
            {
                Attendance attendance = Mapper.Map<AttendanceViewModel, Attendance>(model);
                db.Attendances.Add(attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Attendance/Edit/5
        [Authorize(Roles = "Student")]
        public ActionResult Edit(int? id)
        {
            Attendance attendance = db.Attendances.Find(id);
            AttendanceViewModel model = Mapper.Map<Attendance, AttendanceViewModel>(attendance);
            return View(model);
        }

        // The edit action allow updating existing data in the attendance table/model
        // POST: Attendance/Edit/5
        [Authorize(Roles = "Student")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AttendanceViewModel model)
        {
            if (ModelState.IsValid)
            {
                Attendance attendance = Mapper.Map<AttendanceViewModel, Attendance>(model);
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // The delete action is for deleting a selected item in the table/model
        // GET: Attendance/Delete/5
        [Authorize(Roles = "Student")]
        public ActionResult Delete(int? id)
        {
            Attendance attendance = db.Attendances.Find(id);
            AttendanceViewModel model = Mapper.Map<AttendanceViewModel>(attendance);
            return View(model);
        }

        // The delete action is for deleting a selected item in the table/model
        // POST: Attendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendance attendance = db.Attendances.Find(id);
            db.Attendances.Remove(attendance);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
