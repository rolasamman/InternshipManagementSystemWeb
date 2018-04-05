/*    
 *      Description:    This class is a controller for instructor from the instructor view model
 *      Author:         Rola Samman
*/

using InternshipManagementSystemWeb.Models;
using InternshipManagementSystemWeb.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
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
                    //Mobile = user.Mobile,
                    Department = user.Department
                });
            }
            return View(model);

        }

        // GET: Instructor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Instructor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instructor/Create
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

        // GET: Instructor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Instructor/Edit/5
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

        // GET: Instructor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Instructor/Delete/5
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
