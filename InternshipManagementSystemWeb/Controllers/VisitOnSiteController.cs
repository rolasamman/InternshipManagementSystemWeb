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
    public class VisitOnSiteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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

        // GET: VisitOnSite/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VisitOnSite/Create
        public ActionResult Create()
        {
            return View();
        }

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
            return View();
        }

        // POST: VisitOnSite/Edit/5
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

        // GET: VisitOnSite/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VisitOnSite/Delete/5
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
    }
}
