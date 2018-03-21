﻿using AutoMapper;
using InternshipManagementSystemWeb.Models;
using InternshipManagementSystemWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternshipManagementSystemWeb.Controllers
{
    public class FirmController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Firm
        public ActionResult Index()
        {
            var users = db.Firms.ToList();
            var model = new List<FirmViewModel>();

            foreach (var item in users)
            {
                if (!(item is Firm))
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
            }
            return View(model);
        }

        // GET: Firm/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Firm/Edit/5
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

        // GET: Firm/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Firm/Delete/5
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
