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
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Student
        public ActionResult Index()
        {
            {
                var students = db.Students.ToList();
                var model = new List<StudentViewModel>();

                foreach (var item in students)
                {
                    if (!(item is Student))
                    {
                        model.Add(new StudentViewModel
                        {
                            Id = item.Id,
                            Email = item.Email,
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                        });
                    }
                }
                return View(model);
            }
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            var model = new StudentViewModel
            {
                Id = student.Id ,
                UserName = student.UserName,
                Email = student.Email,
                StudentUniversityId = student.StudentUniversityId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Mobile = student.Mobile,
                Department = student.Department,
                Major = student.Major,
                Resume = student.Resume,
                InternshipAgreementForm = student.InternshipAgreementForm,
                RiskIdentificationForm = student.RiskIdentificationForm
            };

            return View(model);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = db.Students.Find(id);

            if (student == null)
            {
                return HttpNotFound();
            }

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
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    return View(model);
        //}

        //// GET: Student/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}
    }
}
