using AutoMapper;
using InternshipManagementSystemWeb.Models;
using InternshipManagementSystemWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
                    Name = item.Name,
                    FormPath = item.FormPath
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
            InternshipForm form = db.InternshipForms.Find(id);
            if (form == null)
            {
                return HttpNotFound();
            }

            var model = new InternshipFormViewModel
            {
                InternshipFormId = form.InternshipFormId,
                Name = form.Name,
                FormPath = form.FormPath,
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

                var internshipForm = new InternshipForm();
                //TODO Remove invalid characters from the filename such as white spaces
                // check if the uplaoded file is empty (do not upload empty files)
                if (model.FormUpload != null && model.FormUpload.ContentLength > 0)
                {
                    // Allowed extensions to be uploaded
                    var extensions = new[] { "pdf", "docx", "doc" };

                    // using System.IO for Path class
                    // Get the file name without the path
                    string filename = Path.GetFileName(model.FormUpload.FileName);

                    // Get the extension of the file
                    string ext = Path.GetExtension(filename).Substring(1);

                    // Check if the extension of the file is in the list of allowed extensions
                    if (!extensions.Contains(ext, StringComparer.OrdinalIgnoreCase))
                    {
                        ModelState.AddModelError(string.Empty, "Accepted file are pdf, docx, and doc documents");
                        return View();
                    }

                    // Set the application folder where to save the uploaded file
                    string appFolder = "~/Content/Uploads/";


                    // Generate a random string to add to the file name
                    // This is to avoid the files with the same names
                    var rand = Guid.NewGuid().ToString();

                    // Combine the application folder location with the file name
                    string path = Path.Combine(Server.MapPath(appFolder), rand + "-" + filename);

                    // Save the file in ~/Content/Uploads/filename.xyz
                    model.FormUpload.SaveAs(path);

                    //// Add the path to the course object
                    //internshipForm.FormPath = appFolder + rand + "-" + filename;
                    // Create the course from the model
                    internshipForm = new InternshipForm
                    {
                        InternshipFormId = model.InternshipFormId,
                        Name = model.Name,
                        FormPath = appFolder + rand + "-" + model.FormUpload.FileName,
                    };
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Empty files are not accepted");
                    return View();
                }

                // Save the created course to the database
                db.InternshipForms.Add(internshipForm);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
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
