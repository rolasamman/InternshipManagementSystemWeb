using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternshipManagementSystemWeb.Controllers
{
    public class SupervisorEvaluationController : Controller
    {

        // The index action allow displaying and listing the items that are in the supervisorEvaluation table/model
        // GET: SupervisorEvaluation
        public ActionResult Index()
        {
            return View();
        }

        // The details action allow displaying the details of a selected item by Id in the supervisorEvaluation table/model 
        // GET: SupervisorEvaluation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SupervisorEvaluation/Create
        public ActionResult Create()
        {
            return View();
        }

        // The create action allows adding a new item to the supervisorEvaluation table/model
        // POST: SupervisorEvaluation/Create
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

        // GET: SupervisorEvaluation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SupervisorEvaluation/Edit/5
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

        // GET: SupervisorEvaluation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SupervisorEvaluation/Delete/5
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
