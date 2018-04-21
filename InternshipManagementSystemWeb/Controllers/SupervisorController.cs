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
    /// <summary>
    /// Supervisor controller manages supervisors 
    /// This controller uses supervisor and supervisorViewModel classes
    /// This controller users AutoMapper
    /// </summary>

    [Authorize]
    public class SupervisorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // The index action allow displaying and listing the items that are in the supervisor table/model
        // GET: Supervisor
        public ActionResult Index()
        {
            var users = db.Supervisors.ToList();
            var model = new List<SupervisorViewModel>();

            foreach (var item in users)
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
            return View(model);
        }

        // The details action allow displaying the details of a selected item by Id in the supervisor table/model 
        // GET: Supervisor/Details/5
        public ActionResult Details(int id)
        {
            Supervisor supervisor = db.Supervisors.Find(id);           
            var model = new SupervisorViewModel
            {
                SupervisorId = supervisor.SupervisorId,
                FirstName = supervisor.FirstName,
                LastName = supervisor.LastName,
                Email = supervisor.Email,
                Phone = supervisor.Phone,
                Mobile = supervisor.Mobile,
                Department = supervisor.Department,
            };
            return View(model);
        }

        // GET: Supervisor/Create
        public ActionResult Create()
        {
            return View();
        }

        // The create action allows adding a new item to the supervisor table/model
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
            Supervisor supervisor = db.Supervisors.Find(id);
            SupervisorViewModel model = Mapper.Map<Supervisor, SupervisorViewModel>(supervisor);
            return View(model);
        }

        // POST: Supervisor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SupervisorViewModel model)
        {
            if (ModelState.IsValid)
            {
                Supervisor supervisor = Mapper.Map<SupervisorViewModel, Supervisor>(model);
                db.Entry(supervisor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Supervisor/Delete/5
        public ActionResult Delete(int id)
        {
            Supervisor supervisor = db.Supervisors.Find(id);
            SupervisorViewModel model = Mapper.Map<Supervisor, SupervisorViewModel>(supervisor);
            return View(model);
        }

        // POST: Supervisor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supervisor supervisor = db.Supervisors.Find(id);
            db.Supervisors.Remove(supervisor);
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
