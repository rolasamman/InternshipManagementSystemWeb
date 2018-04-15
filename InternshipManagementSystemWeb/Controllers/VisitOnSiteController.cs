/*      
 *      Description:    This class is a controller for visitOnSite from the VisitOnSite view model
 *      Author:         Rola Samman
*/

using AutoMapper;
using InternshipManagementSystemWeb.Models;
using InternshipManagementSystemWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternshipManagementSystemWeb.Controllers
{
    public class VisitOnSiteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // The index action allow displaying and listing the items that are in the visitOnSite table/model
        // GET: VisitOnSite
        public ActionResult Index()
        {
            var visitOnSites = db.VisitOnSites.ToList();
            var model = new List<VisitOnSiteViewModel>();
            foreach (var item in visitOnSites)
            {
                //model.Add(new VisitOnSiteViewModel
                //{
                    
                //});
            }
            return View(model);
        }

        // The details action allow displaying the details of a selected item by Id in the visiteOnSite table/model 
        // GET: VisitOnSite/Details/5
        public ActionResult Details(int id)
        {
            VisitOnSite visitOnSite = db.VisitOnSites.Find(id);
            VisitOnSiteViewModel model = Mapper.Map<VisitOnSite, VisitOnSiteViewModel>(visitOnSite);
            return View(model);
        }

        // GET: VisitOnSite/Create
        public ActionResult Create()
        {
            return View();
        }

        // The create action allows adding a new item to the visitOnSite table/model
        // POST: VisitOnSite/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VisitOnSiteViewModel model)
        {
            if (ModelState.IsValid)
            {
                VisitOnSite visitOnSite = Mapper.Map<VisitOnSiteViewModel, VisitOnSite>(model);
                db.VisitOnSites.Add(visitOnSite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: VisitOnSite/Edit/5
        public ActionResult Edit(int id)
        {
            VisitOnSite visitOnSite = db.VisitOnSites.Find(id);
            VisitOnSiteViewModel model = Mapper.Map<VisitOnSite, VisitOnSiteViewModel>(visitOnSite);
            return View(model);
        }

        // POST: VisitOnSite/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VisitOnSiteViewModel model)
        {
            if (ModelState.IsValid)
            {
                VisitOnSite visitOnSite = Mapper.Map<VisitOnSiteViewModel, VisitOnSite>(model);
                db.Entry(visitOnSite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: VisitOnSite/Delete/5
        public ActionResult Delete(int id)
        {
            VisitOnSite visitOnSite = db.VisitOnSites.Find(id);
            VisitOnSiteViewModel model = Mapper.Map<VisitOnSite, VisitOnSiteViewModel>(visitOnSite);
            return View(model);
        }

        // POST: VisitOnSite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VisitOnSite visitOnSite = db.VisitOnSites.Find(id);
            db.VisitOnSites.Remove(visitOnSite);
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
