/*      Description:    This class is a controller for supervisors from the supervisor view model
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
    /// <summary>
    /// Supervisor controller manages supervisors 
    /// This controller uses supervisor and supervisorViewModel classes
    /// This controller users AutoMapper
    /// </summary>

    public class SupervisorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Supervisor
        public ActionResult Index()
        {
            var users = db.Supervisors.ToList();
            var model = new List<SupervisorViewModel>();

            foreach (var item in users)
            {
                if (!(item is Supervisor))
                {
                    model.Add(new SupervisorViewModel
                    {
                        SupervisorId = item.SupervisorId,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email,
                        Phone = item.Phone,
                        Mobile = item.Mobile,
                        Department = item.Department,
                    });
                }
            }
            return View(model);
        }

        // GET: Supervisor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Supervisor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supervisor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupervisorViewModel model)
        {
            if (ModelState.IsValid)
            {
                Supervisor supervisor = Mapper.Map<SupervisorViewModel, Supervisor>(model);
                db.Supervisors.Add(supervisor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Supervisor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Supervisor/Edit/5
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

        // GET: Supervisor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Supervisor/Delete/5
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

        ////GET: /InternshipCourse/ListSections/5
        //public PartialViewResult ListSupervisorFullName(int id)
        //{
        //    var list = db.Supervisors.ToList().Select(e => new { e.SupervisorId, e.FullName });
        //    ViewBag.SupervisorId = new SelectList(list, "Id", "FullName");
        //}
    }
}
