using AutoMapper;
using InternshipManagementSystemWeb.Models;
using InternshipManagementSystemWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace InternshipManagementSystemWeb.Controllers
{
    public class SectionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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

        // GET: Section/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            SectionViewModel model = Mapper.Map<Section, SectionViewModel>(section);
            return View(model);
        }

        // GET: Section/Create
        public ActionResult Create()
        {
            return View();
        }

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
            return View();
        }

        // POST: Section/Edit/5
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

        // GET: Section/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Section/Delete/5
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
