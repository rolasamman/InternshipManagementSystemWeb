/*      Description:    This class is a controller for complain from the complain view model
 *      Author:         Rola Samman
*/

using AutoMapper;
using InternshipManagementSystemWeb.Models;
using InternshipManagementSystemWeb.ViewModels;
using System;
using System.Collections.Generic;
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Complain/Edit/5
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

        // GET: Complain/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Complain/Delete/5
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
