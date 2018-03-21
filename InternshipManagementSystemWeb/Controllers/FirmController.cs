using InternshipManagementSystemWeb.Models;
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
            return View();
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
