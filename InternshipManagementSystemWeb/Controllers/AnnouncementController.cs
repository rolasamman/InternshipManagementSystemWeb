/*     
 *     Description:    This class is a controller for announcemtn from the announcement view model
 *      Author:        Rola Samman
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
    public class AnnouncementController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // The index action allow displaying and listing the items that are in the announcement table/model
        // GET: Announcement 
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
        public ActionResult Details(int? id)
        {
            Announcement announcement = db.Announcements.Find(id);
            AnnouncementViewModel model = Mapper.Map<Announcement, AnnouncementViewModel>(announcement);
            return View(model);
        }


        // GET: Announcement/Create
        public ActionResult Create()
        {
            return View();
        }

        // The create action allows adding a new item to the announcement table/model
        // POST: Announcement/Create
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
        public ActionResult Edit(int? id)
        {
            Announcement announcement = db.Announcements.Find(id);
            AnnouncementViewModel model = Mapper.Map<Announcement, AnnouncementViewModel>(announcement);
            return View(model); 
        }

        // POST: Announcement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for      
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

        // GET: Announcement/Delete/5
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
