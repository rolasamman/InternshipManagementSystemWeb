/*    
 *      Description:    This is an Internship Management System for a university. 
 *                      The project handles internship matters of the internship department of the university. 
 *                      The aim of the project is to make communications between users most efficient and effective. 
 *                      It also provides users with necessary data and records needed information.
 *      
 *      Author:         Rola Samman
*/

using AutoMapper;
using InternshipManagementSystemWeb.Models;
using InternshipManagementSystemWeb.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternshipManagementSystemWeb.Controllers
{
    /// <summary>
    /// Instructor controller manage instructors using instructor and InstructorViewModel classes
    /// </summary>

    [Authorize]
    public class InstructorController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();

        public InstructorController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public object UserManeger { get; private set; }

        // The index action allow displaying and listing the users that are in the instructor table/model
        // GET: Instructor
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var users = db.Instructors.ToList();
            var model = new List<InstructorViewModel>();

            foreach (var item in users)
            {
                model.Add(new InstructorViewModel
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    EmployeeUniversityId = item.EmployeeUniversityId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Office = item.Office,
                    Phone = item.Phone,
                    Extension = item.Extension,
                    Mobile = item.Mobile,
                    //Department = item.Department
                    //Roles = item.Roles,
                });
            }
            return View(model);
        }

        // The details action allow displaying the details of a selected user by Id in the instructor table/model 
        // GET: Instructor/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            Instructor instructor = db.Instructors.Find(id);
            InstructorViewModel model = Mapper.Map<Instructor, InstructorViewModel>(instructor);
            return View(model);
        }

        // GET: Instructor/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // The create action allows adding a new user to the instructor table/model
        // POST: Instructor/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InstructorViewModel model)
        {
            if (ModelState.IsValid)
            {
                Instructor instructor = Mapper.Map<InstructorViewModel, Instructor>(model);
                db.Instructors.Add(instructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Instructor/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Instructor instructor = db.Instructors.Find(id);
            InstructorViewModel model = Mapper.Map<Instructor, InstructorViewModel>(instructor);
            return View(model);
        }

        // POST: Instructor/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InstructorViewModel model)
        {
            if (ModelState.IsValid)
            {
                Instructor instructor = Mapper.Map<InstructorViewModel, Instructor>(model);
                db.Entry(instructor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Instructor/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
            {
                Instructor instructor = db.Instructors.Find(id);
                InstructorViewModel model = Mapper.Map<Instructor, InstructorViewModel>(instructor);
                return View(model);
            }

        // POST: Instructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instructor instructor = db.Instructors.Find(id);
            db.Instructors.Remove(instructor);
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

        //GET: /Instructors/ListSections/5
        public PartialViewResult ListSectionsPartial(int id)
        {
            var sections = db.Sections.Where(d => d.IntrenshipCourseId == id).ToList();
            var model = new List<SectionViewModel>();
            foreach (var item in sections)
            {
                model.Add(new SectionViewModel
                {
                    SectionId = item.SectionId,
                    Year = item.Year,
                    Capacity = item.Capacity,
                    //Semester = item.Semester,
                });
            }
            return PartialView(model);
        }
    }
}
