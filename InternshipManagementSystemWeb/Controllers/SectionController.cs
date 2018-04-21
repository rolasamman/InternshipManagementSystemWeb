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
    public class SectionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // The index action allow displaying and listing the items that are in the section table/model
        // GET: Section
        public ActionResult Index()
        {
            var sections = db.Sections.ToList();

            var model = new List<SectionViewModel>();
            foreach (var item in sections)
            {
                model.Add(new SectionViewModel
                {
                    SectionId = item.SectionId,
                    //Semester = item.Semester,
                    Year = item.Year,
                    Capacity = item.Capacity
                });
            }
            return View(model);
        }

        // The details action allow displaying the details of a selected item by Id in the section table/model 
        // GET: Section/Details/5
        public ActionResult Details(int? id)
        {
            Section section = db.Sections.Find(id);
            SectionViewModel model = Mapper.Map<Section, SectionViewModel>(section);
            return View(model);
        }

        // GET: Section/Create
        public ActionResult Create()
        {
            return View();
        }

        // The create action allows adding a new item to the section table/model
        // POST: Section/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SectionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Section section = Mapper.Map<SectionViewModel, Section>(model);
                db.Sections.Add(section);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Section/Edit/5
        public ActionResult Edit(int id)
        {
            Section section = db.Sections.Find(id);
            SectionViewModel model = Mapper.Map<Section, SectionViewModel>(section);
            return View(model);
        }

        // POST: Section/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SectionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Section section = Mapper.Map<SectionViewModel, Section>(model);
                db.Entry(section).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Section/Delete/5
        public ActionResult Delete(int id)
        {
            Section section = db.Sections.Find(id);
            SectionViewModel model = Mapper.Map<Section, SectionViewModel>(section);
            return View(model);
        }

        // POST: Section/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Section section = db.Sections.Find(id);
            db.Sections.Remove(section);
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

        // GET: /Section/ListStudents/5
        //public PartialViewResult ListStudentsPartial(int id)
        //{
        //    var users = db.Students.Where(d => d.StudentUniversityId == id).ToList();
        //    var model = new List<StudentViewModel>();
        //    foreach (var user in users)
        //    {
        //        model.Add(new StudentViewModel
        //        {
        //            Id = user.Id,
        //            Email = user.Email,
        //            FirstName = user.FirstName,
        //            LastName = user.LastName,
        //            Department = user.Department.Name,
        //        });
        //    }
        //    return PartialView(model);
        //}
    }
}
