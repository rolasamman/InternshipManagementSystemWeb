/*    
 *      Description:    This is an Internship Management System for a university. 
 *                      The project handles internship matters of the internship department of the university. 
 *                      The aim of the project is to make communications between users most efficient and effective. 
 *                      It also provides users with necessary data and records needed information.
 *      
 *      Author:         Rola Samman
*/

using InternshipManagementSystemWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternshipManagementSystemWeb.Controllers
{
    [Authorize]
    public class SupervisorEvaluationController : Controller
    {

        // The index action allow displaying and listing the items that are in the supervisorEvaluation table/model
        // GET: SupervisorEvaluation
        //public ActionResult Index()
        //{
        //    // Create the list of possible answers for questions
        //    // Each questions may have a different number of answers
        //    // In this case all questions have 5 possible answers
        //    var possibleAnswers = new List<SupervisorAnswerViewModel>
        //    {
        //        new SupervisorAnswerViewModel { Id = 1, Text= "Definitely Excptional"},
        //        new SupervisorAnswerViewModel { Id = 2, Text= "Abouve Average"},
        //        new SupervisorAnswerViewModel { Id = 3, Text= "Average"},
        //        new SupervisorAnswerViewModel { Id = 4, Text= "Below Average"},
        //        new SupervisorAnswerViewModel { Id = 5, Text= "Poor"},
        //    };

        //    // Get the questions from the database
        //    // This is a data sample
        //    var questions = new List<SupervisorCriterionViewModel>
        //    {
        //        // Rdio button input
        //        new SupervisorCriterionViewModel
        //        {
        //            SupervisorCriterionId = 1,
        //            Question = "Question 1",
        //            QuestionInputType = QuestionInputType.RadioButton,
        //            PossibleAnswers = possibleAnswers,
        //        },

        //        // Textbox input
        //        new SupervisorCriterionViewModel
        //        {
        //            SupervisorCriterionId = 2,
        //            Question = "Question 2",
        //            QuestionInputType = QuestionInputType.TextBox,
        //        },

        //        // Text Area input
        //        new SupervisorCriterionViewModel
        //        {
        //            SupervisorCriterionId = 3,
        //            Question = "Question 3",
        //            QuestionInputType = QuestionInputType.TextArea,
        //        }
        //    };
        //}

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
