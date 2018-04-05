﻿/*  
 *      Description:    This class is a controller for internship course from the internship course view model
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
    public class InternshipCourseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InternshipCourse
        public ActionResult Index()
        {
            var internshipCourses = db.InternshipCourses.ToList();

            var model = new List<InternshipCourseViewModel>();
            foreach (var item in internshipCourses)
            {
                model.Add(new InternshipCourseViewModel
                {
                    InternshipCourseId = item.InternshipCourseId,
                    CourseCode = item.CourseCode,
                    CourseName = item.CourseName,
                    Description = item.Description,
                    Credits = item.Credits,

                });
            }
            return View(model);
        }

        // GET: InternshipCourse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InternshipCourse internshipCourse = db.InternshipCourses.Find(id);
            if (internshipCourse == null)
            {
                return HttpNotFound();
            }

            InternshipCourseViewModel model = Mapper.Map<InternshipCourse, InternshipCourseViewModel>(internshipCourse);

            return View(model);
        }

        // GET: InternshipCourse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InternshipCourse/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InternshipCourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                InternshipCourse internshipCourse = Mapper.Map<InternshipCourseViewModel, InternshipCourse>(model);
                db.InternshipCourses.Add(internshipCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: InternshipCourse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            InternshipCourse internshipCourse = db.InternshipCourses.Find(id);
            if (internshipCourse == null)
            {
                return HttpNotFound();
            }
            InternshipCourseViewModel model = Mapper.Map<InternshipCourse, InternshipCourseViewModel>(internshipCourse);
            return View(model);
        }

        // POST: InternshipCourse/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InternshipCourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                InternshipCourse internshipCourse = Mapper.Map<InternshipCourseViewModel, InternshipCourse>(model);
                db.Entry(internshipCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: InternshipCourse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InternshipCourse internshipCourse = db.InternshipCourses.Find(id);
            if (internshipCourse == null)
            {
                return HttpNotFound();
            }
            InternshipCourseViewModel model = Mapper.Map<InternshipCourseViewModel>(internshipCourse);
            return View(model);
        }

        // POST: InternshipCourse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InternshipCourse internshipCourse = db.InternshipCourses.Find(id);
            db.InternshipCourses.Remove(internshipCourse);
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

        //GET: /InternshipCourse/ListSections/5
        //public PartialViewResult ListSectionsPartial(int id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var sections = db.Sections.Where(c => c.IntrenshipCourseId == id).ToList();

        //    var model = new List<SectionViewModel>();
        //    foreach (var section in sections)
        //    {
        //        model.Add(new SectionViewModel
        //        {
        //            SectionId = section.SectionId,
        //            Semester = section.Semester,
        //            Year = section.Year,
        //            Capacity = section.Capacity
        //        });
        //    }
        //    return PartialView(model);
        //}
    }
}