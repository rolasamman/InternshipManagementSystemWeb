﻿/*    
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
    [Authorize]
    public class FirmController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // The index action allow displaying and listing the items that are in the firm table/model
        // GET: Firm
        [Authorize(Roles = "Admin, Instructor, Student")]
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
        [Authorize(Roles = "Admin, Instructor, Student")]
        public ActionResult Details(int? id)
        {
            Firm firm = db.Firms.Find(id);
            FirmViewModel model = Mapper.Map<Firm, FirmViewModel>(firm); 
            return View(model);
        }

        // GET: Firm/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // The create action allows adding a new item to the firm table/model
        // POST: Firm/Create
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            Firm firm = db.Firms.Find(id);          
            FirmViewModel model = Mapper.Map<Firm, FirmViewModel>(firm);
            return View(model);
        }

        // POST: Firm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
