using InternshipManagementSystemWeb.Models;
using InternshipManagementSystemWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }

        // GET: Section/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Section/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Section/Create
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
