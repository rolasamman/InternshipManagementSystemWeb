﻿/*      
 *      Description:    This class is a controller for student from the student view model
 *      Author:         Rola Samman
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
    /// <summary>
    /// Student controller manages students 
    /// This controller uses student and studentViewModel classes
    /// This controller uses AutoMapper
    /// Students are application users
    /// </summary>

    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // The index action allow displaying and listing the users that are in the student table/model
        // GET: Student
        public ActionResult Index()
        {
            {
                var users = db.Students.ToList();
                var model = new List<StudentViewModel>();

                foreach (var item in users)
                {
                    model.Add(new StudentViewModel
                    {
                        Id = item.Id,
                        UserName = item.UserName,
                        StudentUniversityId = item.StudentUniversityId,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email,                        
                        Mobile = item.Mobile,
                        //Department=item.Department,
                        Major =item.Major,
                        Resume = item.Resume,
                        InternshipAgreementForm = item.InternshipAgreementForm,
                        RiskIdentificationForm = item.RiskIdentificationForm,
                    });
                }
                return View(model);              
            }
        }

        // The details action allow displaying the details of a selected user by Id in the student table/model 
        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            Student student = db.Students.Find(id);
            StudentViewModel model = Mapper.Map<Student, StudentViewModel>(student);
            return View(model);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // The create action allows adding a new user to the student table/model
        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel model)
        {
            if (ModelState.IsValid)
            { 
                Student student = Mapper.Map<StudentViewModel, Student>(model);
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          return View(model);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            Student student = db.Students.Find(id);
            StudentViewModel model = Mapper.Map<Student, StudentViewModel>(student);
            return View(model);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Student student = Mapper.Map<StudentViewModel, Student>(model);
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Student student = db.Students.Find(id);
            StudentViewModel model = Mapper.Map<Student, StudentViewModel>(student);
            return View(model);
        }

        //// GET: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
