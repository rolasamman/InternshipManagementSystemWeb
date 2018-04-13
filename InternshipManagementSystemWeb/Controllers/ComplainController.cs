/*
 *      Description:    This class is a controller for complain from the complain view model
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
    public class ComplainController : Controller 
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Complain
        public ActionResult Index()
        {
            var complains = db.Complains.ToList();
            var model = new List<ComplainViewModel>();
            foreach (var item in complains)
            {
                model.Add(new ComplainViewModel
                {
                   ComplainId = item.ComplainId,
                   Title = item.Title,
                   Description = item.Description,
                   //CreationDate = item.CreationDate,
                   //ComplainStatus = item.ComplainStatus
                });
            }
            return View(model);
        }


        // GET: Complain/Details/5
        public ActionResult Details(int? id)
        {
            Complain complain = db.Complains.Find(id);
            ComplainViewModel model = Mapper.Map<Complain, ComplainViewModel>(complain);
            return View(model); 
        }

        // GET: Complain/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Complain/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComplainViewModel model)
        {
            if (ModelState.IsValid)
            {
                Complain complain = Mapper.Map<ComplainViewModel, Complain>(model);
                complain.CreationDate = DateTime.Now;
                db.Complains.Add(complain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Complain/Edit/5
        public ActionResult Edit(int? id)
        {
            Complain complain = db.Complains.Find(id);
            ComplainViewModel model = Mapper.Map<Complain, ComplainViewModel>(complain);
            return View(model);
        }

        // POST: Complain/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ComplainViewModel model)
        {
            if (ModelState.IsValid)
            {
                Complain complain = Mapper.Map<ComplainViewModel, Complain>(model);
                db.Entry(complain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Complain/Delete/5
        public ActionResult Delete(int id)
        {
            Complain complain = db.Complains.Find(id);
            ComplainViewModel model = Mapper.Map<Complain, ComplainViewModel>(complain);
            return View(model);
        }

        // POST: Complain/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Complain complain = db.Complains.Find(id);
            db.Complains.Remove(complain);
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
