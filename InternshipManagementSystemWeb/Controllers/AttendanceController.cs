/*    
 *      Description:    This class is a controller for attendance from the attendance view model
 *      Author:         Rola Samman
*/

using AutoMapper;
using InternshipManagementSystemWeb.Models;
using InternshipManagementSystemWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace InternshipManagementSystemWeb.Controllers
{
    public class AttendanceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Attendance
        public ActionResult Index()
        {
            var attendances = db.Attendances.ToList();
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

        // GET: Attendance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            AttendanceViewModel model = Mapper.Map<Attendance, AttendanceViewModel>(attendance);
            return View(model);
        }

        // GET: Attendance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Attendance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            AttendanceViewModel model = Mapper.Map<Attendance, AttendanceViewModel>(attendance);
            return View(model);
        }

        // POST: Attendance/Edit/5
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


        // GET: Attendance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            AttendanceViewModel model = Mapper.Map<AttendanceViewModel>(attendance);
            return View(model);
        }

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
