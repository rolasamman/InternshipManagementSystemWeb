/*   
 *      Description:    This class is a controller for firm from the firm view model
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
    public class FirmController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // The index action allow displaying and listing the items that are in the firm table/model
        // GET: Firm
        public ActionResult Index()
        {
            var firms = db.Firms.ToList();     
            var model = new List<FirmViewModel>();

            foreach (var item in firms)
            {
                model.Add(new FirmViewModel
                {
                    FirmId = item.FirmId,
                    FirmName = item.FirmName,
                    Address = item.Address,
                    IndustryField = item.IndustryField,
                    NumberOfVacencies = item.NumberOfVacencies,
                    FirmDescription = item.FirmDescription,
                    MapLink = item.MapLink,
                    Logo = item.Logo,
                });
            }
            return View(model);
        }


        // The details action allow displaying the details of a selected item by Id in the firm table/model 
        // GET: Firm/Details/5
        public ActionResult Details(int? id)
        {
            Firm firm = db.Firms.Find(id);
            FirmViewModel model = Mapper.Map<Firm, FirmViewModel>(firm); 
            return View(model);
        }

        // GET: Firm/Create
        public ActionResult Create()
        {
            return View();
        }

        // The create action allows adding a new item to the firm table/model
        // POST: Firm/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FirmViewModel model)
        {
            if (ModelState.IsValid)
            {
                Firm firm = Mapper.Map<FirmViewModel, Firm>(model);
                db.Firms.Add(firm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model); 
        }

        // GET: Firm/Edit/5
        public ActionResult Edit(int? id)
        {
            Firm firm = db.Firms.Find(id);          
            FirmViewModel model = Mapper.Map<Firm, FirmViewModel>(firm);
            return View(model);
        }

        // POST: Firm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FirmViewModel model)
        {
            if (ModelState.IsValid)
            {
                Firm firm = Mapper.Map<FirmViewModel, Firm>(model);
                db.Entry(firm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        } 


        // GET: Firm/Delete/5
        public ActionResult Delete(int? id)
        {
            Firm firm = db.Firms.Find(id);
            FirmViewModel model = Mapper.Map<FirmViewModel>(firm);
            return View(model);
        }

        // POST: Firm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Firm firm = db.Firms.Find(id);
            db.Firms.Remove(firm);
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

        //GET: /Firm/ListSupervisors/5
        public PartialViewResult ListSupervisorsPartial(int id)
        {
            var supervisors = db.Supervisors.Where(c => c.FirmId == id).ToList();
            var model = new List<SupervisorViewModel>();
            foreach (var supervisor in supervisors)
            {
                model.Add(new SupervisorViewModel
                {
                    FirstName = supervisor.FirstName,
                    LastName = supervisor.LastName,
                    Email = supervisor.Email,
                    Phone = supervisor.Phone,
                    Mobile = supervisor.Mobile,
                    Department = supervisor.Department,
                });
            }
            return PartialView(model); 
        }
    }
}
