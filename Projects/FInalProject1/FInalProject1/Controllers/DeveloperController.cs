using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FInalProject1.DAL;
using FInalProject1.Models;

namespace FInalProject1.Controllers
{
    public class DeveloperController : Controller
    {
        private FinalProjectContext db = new FinalProjectContext();

        // GET: Developer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult IndexPost(string email, string password)
        {
            var developer = db.Developers.Where(d => d.Email == email && d.Password == password).SingleOrDefault();
            if (developer != null)
                return RedirectToAction("Profile", new { id = developer.DeveloperID });
            else
            {
                ModelState.AddModelError("", "Invalid Email or Password!");
                return View(developer);
            }
        }

        public ActionResult Home()
        {
            return View();
        }

        public new ActionResult Profile(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var developer = db.Developers.Find(id);
            if (developer == null)
                return HttpNotFound();

            return View(developer);
        }

        public ActionResult EditEducation(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var education = db.EducationList.Find(id);
            if (education == null)
                return HttpNotFound();

            return View(education);
        }

        [HttpPost, ActionName("EditEducation")]
        [ValidateAntiForgeryToken]
        public ActionResult EditEducationPost(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var education = db.EducationList.Find(id);
            var binded = new string[] { "School", "Degree", "Field", "Grade", "StartYear", "EndYear" };
            if (TryUpdateModel(education, "", binded))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Profile", new { id });
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Update Failed!");
                }
            }

            return View(education);
        }

        public ActionResult AddSkill(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var developer = db.Developers.Find(id);
            if (developer == null)
                return HttpNotFound();

            return View("AddSkill", developer);
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
