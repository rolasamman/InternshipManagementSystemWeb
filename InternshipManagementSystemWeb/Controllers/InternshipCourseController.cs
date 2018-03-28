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
    public class InternshipCourseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InternshipCourse
        public ActionResult Index()
        {
            {
                var students = db.Students.ToList();
                var model = new List<StudentViewModel>();

                foreach (var item in students)
                {
                    if (!(item is Student))
                    {
                        model.Add(new StudentViewModel
                        {
                            Id = item.Id,
                            Email = item.Email,
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                        });
                    }
                }
                return View(model);
            }
        }

        // GET: InternshipCourse/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InternshipCourse/Edit/5
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

        // GET: InternshipCourse/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InternshipCourse/Delete/5
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

        // GET: /InternshipCourse/ListSections/5
        //public PartialViewResult ListSectionsPartial(int id)
        //{
        //    var users = db.section.Where(d => d.InternshipCourseId == id).ToList();

        //    var model = new List<SectionViewModel>();
        //    foreach (var user in users)
        //    {
        //        model.Add(new SectionViewModel
        //        {
        //            Id = user.Id,

        //            Email = user.Email,

        //            FirstName = user.FirstName,

        //            LastName = user.LastName,

        //            Speciality = user.Speciality,

        //            Level = user.Level,

        //            Department = user.Department.Name,
        //        });
        //    }
            //return PartialView(model);
        }
}
