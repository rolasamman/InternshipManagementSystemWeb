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
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace InternshipManagementSystemWeb.Controllers
{
    [Authorize]
    public class InternshipCourseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // The index action allow displaying and listing the items that are in the internshipCourse table/model
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

        // The details action allow displaying the details of a selected item by Id in the internshipCourse table/model 
        // GET: InternshipCourse/Details/5
        public ActionResult Details(int? id)
        {
            InternshipCourse internshipCourse = db.InternshipCourses.Find(id);
            InternshipCourseViewModel model = Mapper.Map<InternshipCourse, InternshipCourseViewModel>(internshipCourse);
            return View(model);
        }

        // GET: InternshipCourse/Create
        public ActionResult Create()
        {
            return View();
        }

        // The create action allows adding a new item to the internshipCourse table/model
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
            InternshipCourse internshipCourse = db.InternshipCourses.Find(id);
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
            InternshipCourse internshipCourse = db.InternshipCourses.Find(id);
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
        public PartialViewResult ListSectionsPartial(int id)
        {
            var sections = db.Sections.Where(c => c.IntrenshipCourseId == id).ToList();
            var model = new List<SectionViewModel>();
            foreach (var section in sections)
            {
                model.Add(new SectionViewModel
                {
                    SectionId = section.SectionId,
                    //Semester = section.Semester,
                    Year = section.Year,
                    Capacity = section.Capacity
                });
            }
            return PartialView(model); 
        }
    }
}