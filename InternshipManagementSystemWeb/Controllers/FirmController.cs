﻿using AutoMapper;
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
    public class FirmController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Firm
        //public ActionResult Index()
        //{
        //    var users = db.Firms.ToList();
        //    var model = new List<FirmViewModel>();

        //    foreach (var item in users)
        //    {
        //        if (!(item is Firm))
        //        {
        //            model.Add(new FirmViewModel
        //            {
        //                FirmId = item.FirmId,
        //                FirmName = item.FirmName,
        //                Address = item.Address,
        //                IndustryField = item.IndustryField,
        //                NumberOfVacencies = item.NumberOfVacencies,
        //            });
        //        }
        //    }
        //    return View(model);
        //}

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
                });
            }
            return View(model);
        }


        // GET: Firm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firm firm = db.Firms.Find(id);
            if (firm == null)
            {
                return HttpNotFound();
            }

            FirmViewModel model = Mapper.Map<Firm, FirmViewModel>(firm);

            return View(model);
        }

        // GET: Firm/Create
        public ActionResult Create()
        {
            return View();
        }

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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Firm firm = db.Firms.Find(id);
            if (firm == null)
            {
                return HttpNotFound();
            }
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firm firm = db.Firms.Find(id);
            if (firm == null)
            {
                return HttpNotFound();
            }
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
    }
}
