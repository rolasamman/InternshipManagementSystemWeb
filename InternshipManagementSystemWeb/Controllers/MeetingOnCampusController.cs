using InternshipManagementSystemWeb.Models;
using InternshipManagementSystemWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternshipManagementSystemWeb.Controllers
{
    public class MeetingOnCampusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MeetingOnCampus
        //public ActionResult Index()
        //{
        //    //var meetingOnCampuses = db.MeetingOnCampuses.ToList();

        //    //var model = new List<MeetingOnCampusViewModel>();
        //    //foreach (var item in meetingOnCampuses)
        //    //{
        //    //    model.Add(new MeetingOnCampusViewModel
        //    //    {
        //    //        MeetingOnCampusId = item. 
        //    //    });
        //    //}
        //    //return View(model);
        //}

        // GET: MeetingOnCampus/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MeetingOnCampus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MeetingOnCampus/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MeetingOnCampus/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MeetingOnCampus/Edit/5
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

        // GET: MeetingOnCampus/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MeetingOnCampus/Delete/5
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
