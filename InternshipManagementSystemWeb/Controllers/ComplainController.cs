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
    /// Complain controller manages complains 
    /// This controller uses complain model and complain viewModel
    /// </summary>

    [Authorize]
    public class ComplainController : Controller 
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // The index action allow displaying and listing the items that are in the complain table/model
        // GET: Complain
        [Authorize(Roles = "Admin, Student")]
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

        // The details action allow displaying the details of a selected item by Id in the complain table/model 
        // GET: Complain/Details/5
        [Authorize(Roles = "Admin, Student")]
        public ActionResult Details(int? id)
        {
            Complain complain = db.Complains.Find(id);
            ComplainViewModel model = Mapper.Map<Complain, ComplainViewModel>(complain);
            return View(model); 
        }

        // GET: Complain/Create
        [Authorize(Roles = "Student")]
        public ActionResult Create()
        {
            return View();
        }

        // The create action allows adding a new item to the complain table/model
        // POST: Complain/Create
        [Authorize(Roles = "Student")]
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
        [Authorize(Roles = "Student")]
        public ActionResult Edit(int? id)
        {
            Complain complain = db.Complains.Find(id);
            ComplainViewModel model = Mapper.Map<Complain, ComplainViewModel>(complain);
            return View(model);
        }

        // The edit action allow updating selected existing data in the complain table/model
        // POST: Complain/Edit/5
        [Authorize(Roles = "Student")]
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

        // The delete action is for deleting a selected item in the table/model
        // GET: Complain/Delete/5
        [Authorize(Roles = "Student")]
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

        // POST: Complain/Reply
        //[Authorize(Roles = "Admin, Student")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public PartialViewResult ReplyPartial(int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Complain reply = Mapper.Map<ComplainViewModel, Complain>();
        //        reply.ReplyDate = DateTime.Now;
        //        db.Complains.Add(reply);
        //        db.SaveChanges();
        //    }
        //    return PartialView(model);
        //}
    }
}
