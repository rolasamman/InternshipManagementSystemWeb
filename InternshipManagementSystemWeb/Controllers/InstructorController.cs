/*    
 *      Description:    This class is a controller for instructor from the instructor view model
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
    public class InstructorController : Controller
    {
        /// <summary>
        /// Instructor controller manage instructors using instructor and InstructorViewModel classes
        /// </summary>

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
        public ActionResult Index()
        {
            var users = db.Instructors.ToList();
            var model = new List<InstructorViewModel>();
            foreach (var user in users)
            {
                model.Add(new InstructorViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    EmployeeUniversityId = user.EmployeeUniversityId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Office = user.Office,
                    Phone = user.Phone,
                    Extension = user.Extension,
                    Mobile = user.Mobile,
                    //Department = user.Department.
                });
            }
            return View(model);
        }

        // The details action allow displaying the details of a selected user by Id in the instructor table/model 
        // GET: Instructor/Details/5
        public ActionResult Details(int id)
        {
            Instructor instructor = db.Instructors.Find(id);
            InstructorViewModel model = Mapper.Map<Instructor, InstructorViewModel>(instructor);
            return View(model);
        }

        // GET: Instructor/Create
        public ActionResult Create()
        {
            return View();
        }

        // The create action allows adding a new user to the instructor table/model
        // POST: Instructor/Create
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
        public ActionResult Edit(int id)
        {
            Instructor instructor = db.Instructors.Find(id);
            InstructorViewModel model = Mapper.Map<Instructor, InstructorViewModel>(instructor);
            return View(model);
        }

    // POST: Instructor/Edit/5
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

        //
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
