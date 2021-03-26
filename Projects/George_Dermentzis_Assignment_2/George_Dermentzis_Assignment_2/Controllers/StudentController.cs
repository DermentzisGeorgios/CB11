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
    public class StudentController : Controller
    {
        private readonly Assignment_2Context context;
        private readonly StudentRepository repository;

        public StudentController()
        {
            context = new Assignment_2Context();
            repository = new StudentRepository(context);
        }


        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult> Get()
        {
            var students = await repository.GetAll();
            if (students == null) return HttpNotFound("There aren't any students!");

            return View("StudentIndex", students);
        }

        [HttpGet]
        public async Task<ActionResult> Get(int id)
        {
            if (id == 0) return View("StudentForm", new Student(id));

            var student = await repository.GetById(id);
            if (student == null) return HttpNotFound("No student found!");

            return View("StudentForm", student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Post(StudentViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("StudentForm", viewModel);

            repository.CreateOrUpdate(new Student(viewModel));

            return RedirectToAction("Get", "Student");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id == 0) return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid Id!");

            repository.Delete(id);

            return RedirectToAction("Get", "Student");
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
    }
}