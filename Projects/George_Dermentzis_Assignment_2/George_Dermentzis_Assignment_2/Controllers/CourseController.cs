using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using George_Dermentzis_Assignment_2.DAL;
using George_Dermentzis_Assignment_2.Models;
using George_Dermentzis_Assignment_2.Repositories;
using George_Dermentzis_Assignment_2.ViewModels;

namespace George_Dermentzis_Assignment_2.Controllers
{
    public class CourseController : Controller
    {
        private readonly Assignment_2Context context;
        private readonly CourseRepository repository;

        public CourseController()
        {
            context = new Assignment_2Context();
            repository = new CourseRepository(context);
        }


        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult> Get()
        {
            var courses = await repository.GetAll();
            if (courses == null) return HttpNotFound("There aren't any courses!");

            return View("CourseIndex", courses);
        }

        [HttpGet]
        public async Task<ActionResult> Get(int id)
        {
            if (id == 0) return View("CourseForm", new Course(id));

            var course = await repository.GetById(id);
            if (course == null) return HttpNotFound("No course found!");

            return View("CourseForm", course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Post(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("CourseForm", viewModel);

            repository.CreateOrUpdate(new Course(viewModel));

            return RedirectToAction("Get", "Course");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id == 0) return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid Id!");

            repository.Delete(id);

            return RedirectToAction("Get", "Course");
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
    }
}