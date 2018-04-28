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
    public class InternshipFormController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InternshipForm
        [Authorize(Roles = "Admin, Instructor, Student")]
        public ActionResult Index()
        {
            var internshipForms = db.InternshipForms.ToList();
            var model = new List<InternshipFormViewModel>();

            foreach (var item in internshipForms)
            {
                model.Add(new InternshipFormViewModel
                {
                    InternshipFormId = item.InternshipFormId,
                    InternshipAgreementForm = item.InternshipAgreementForm,
                    InternshipBooklet = item.InternshipBooklet,
                    RiskIdentificationForm = item.RiskIdentificationForm,
                });
            }
            return View(model);
        }

        // GET: InternshipForm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InternshipForm internshipForm = db.InternshipForms.Find(id);
            if (internshipForm == null)
            {
                return HttpNotFound();
            }

            var model = new InternshipFormViewModel
            {
                InternshipFormId = internshipForm.InternshipFormId,
                InternshipAgreementForm =internshipForm.InternshipAgreementForm,
                RiskIdentificationForm = internshipForm.RiskIdentificationForm,
                InternshipBooklet = internshipForm.InternshipBooklet,
            };

            return View(model);
        }

        // GET: InternshipForm/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: InternshipForm/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InternshipFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                InternshipForm internshipForm = Mapper.Map<InternshipFormViewModel, InternshipForm>(model);      
                db.InternshipForms.Add(internshipForm);
                db.SaveChanges();
                return RedirectToAction("Details");
            }

            return View(model);
        }

        // GET: InternshipForm/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InternshipForm/Edit/5
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

        // GET: InternshipForm/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InternshipForm/Delete/5
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
