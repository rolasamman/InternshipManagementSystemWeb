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
    public class AnnouncementController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Announcement
        public ActionResult Index()
        {
            var users = db.Announcements.ToList();
            var model = new List<AnnouncementViewModel>();

            foreach (var item in users)
            {
                if (!(item is Announcement))
                {
                    model.Add(new AnnouncementViewModel
                    {
                      AnnouncementId = item.AnnouncementId,
                      Subject = item.Subject,
                      AnnouncementDate = item.AnnouncementDate,
                      Description = item.Description
                    });
                }
            }
            return View();
        }

        // GET: Announcement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Announcement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Announcement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnnouncementViewModel model)
        {
            if (ModelState.IsValid)
            {
                Announcement announcement = Mapper.Map<AnnouncementViewModel, Announcement>(model);
                db.Announcements.Add(announcement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Announcement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Announcement/Edit/5
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

        // GET: Announcement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Announcement/Delete/5
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
