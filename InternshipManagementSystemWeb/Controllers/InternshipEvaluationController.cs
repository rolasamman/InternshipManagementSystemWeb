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
    public class InternshipEvaluationController : Controller
    {
        // The index action allow displaying and listing the items that are in the internsihpEvaluation table/model
        // GET: InternshipEvaluation
        //public ActionResult Index()
        //{
        //    // Create the list of possible answers for questions
        //    // Each questions may have a different number of answers
        //    // In this case all questions have 3 possible answers
        //    var possibleAnswers = new List<StudentAnswerViewModel>
        //    {
        //        new StudentAnswerViewModel { Id = 1, Text= "Fair"},
        //        new StudentAnswerViewModel { Id = 2, Text= "Average"},
        //        new StudentAnswerViewModel { Id = 3, Text= "Good"},
        //    };
     //   Extremely Valuable
     //* Very Valuable
     //* Valuable
     //* Of Some Value
     //* Of No Value

        //    // Get the questions from the database
        //    // This is a data sample
        //    var questions = new List<InternshipCriterionViewModel>
        //    {
        //        // Rdio button input
        //        new InternshipCriterionViewModel
        //        {
        //            Id = 1,
        //            Text = "Question 1",
        //            QuestionInputType = QuestionInputType.RadioButton,
        //            PossibleAnswers = possibleAnswers,
        //        },

        //        // Textbox input
        //        new InternshipCriterionViewModel
        //        {
        //            Id = 2,
        //            Text = "Question 2",
        //            QuestionInputType = QuestionInputType.TextBox,
        //        },

        //        // Text Area input
        //        new InternshipCriterionViewModel
        //        {
        //            Id = 3,
        //            Text = "Question 3",
        //            QuestionInputType = QuestionInputType.TextArea,
        //        }
        //}

        // The details action allow displaying the details of a selected item by Id in the internshipEvaluation table/model 
        // GET: InternshipEvaluation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InternshipEvaluation/Create
        public ActionResult Create()
        {
            return View();
        }

        // The create action allows adding a new item to the internshipEvaluation table/model
        // POST: InternshipEvaluation/Create
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

        // GET: InternshipEvaluation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InternshipEvaluation/Edit/5
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

        // GET: InternshipEvaluation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InternshipEvaluation/Delete/5
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
