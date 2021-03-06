﻿/*    
 *      Description:    This is an Internship Management System for a university. 
 *                      The project handles internship matters of the internship department of the university. 
 *                      The aim of the project is to make communications between users most efficient and effective. 
 *                      It also provides users with necessary data and records needed information.
 *      
 *      Author:         Rola Samman
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternshipManagementSystemWeb.Controllers
{
    [Authorize]
    public class SupervisorCriterionController : Controller
    {
        // The index action allow displaying and listing the items that are in the supervisorCriterion table/model
        // GET: SupervisorCriterion
        public ActionResult Index()
        {
            return View();
        }

        // The details action allow displaying the details of a selected item by Id in the supervisorCriterion table/model 
        // GET: SupervisorCriterion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SupervisorCriterion/Create
        public ActionResult Create()
        {
            return View();
        }

        // The create action allows adding a new item to the supervisorCriterion table/model
        // POST: SupervisorCriterion/Create
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

        // GET: SupervisorCriterion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SupervisorCriterion/Edit/5
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

        // GET: SupervisorCriterion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SupervisorCriterion/Delete/5
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
