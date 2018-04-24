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
    /// Announcement controller manages announements 
    /// This controller uses announcement model and announcement viewModel
    /// </summary>

    [Authorize]
    public class AnnouncementController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // The index action allow displaying and listing the items that are in the announcement table/model
        // GET: Announcement 
        [Authorize(Roles = "Admin, Instructor, Student")]
        public ActionResult Index() 
        {
            var announcements = db.Announcements.ToList();
            var model = new List<AnnouncementViewModel>();

            foreach (var item in announcements)
            {
                model.Add(new AnnouncementViewModel
                {
                 AnnouncementId = item.AnnouncementId,
                 AnnouncementDate = item.AnnouncementDate,
                 Subject = item.Subject,
                 Description = item.Description
                });
            }
            return View(model);
        }

        // The details action allow displaying the details of a selected item by Id in the announcement table/model 
        // GET: Announcement/Details/5
        [Authorize(Roles = "Admin, Instructor, Student")]
        public ActionResult Details(int? id)
        {
            Announcement announcement = db.Announcements.Find(id);
            AnnouncementViewModel model = Mapper.Map<Announcement, AnnouncementViewModel>(announcement);
            return View(model);
        }

        // GET: Announcement/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // The create action allows adding a new item to the announcement table/model
        // POST: Announcement/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnnouncementViewModel model)
        {
            if (ModelState.IsValid)
            {
                Announcement announcement = Mapper.Map<AnnouncementViewModel, Announcement>(model);
                announcement.AnnouncementDate = DateTime.Now;
                db.Announcements.Add(announcement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Announcement/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            Announcement announcement = db.Announcements.Find(id);
            AnnouncementViewModel model = Mapper.Map<Announcement, AnnouncementViewModel>(announcement);
            return View(model); 
        }

        // The edit action allow updating existing data in the announcement table/model
        // POST: Announcement/Edit/5   
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AnnouncementViewModel model)
        {
            if (ModelState.IsValid)
            {
                Announcement announcement = Mapper.Map<AnnouncementViewModel, Announcement>(model);
                db.Entry(announcement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // The delete action is for deleting a selected item in the table/model
        // GET: Announcement/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            Announcement announcement = db.Announcements.Find(id);
            AnnouncementViewModel model = Mapper.Map<AnnouncementViewModel>(announcement);
            return View(model);
        }

        // POST: Announcement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Announcement announcement = db.Announcements.Find(id);
            db.Announcements.Remove(announcement);
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
