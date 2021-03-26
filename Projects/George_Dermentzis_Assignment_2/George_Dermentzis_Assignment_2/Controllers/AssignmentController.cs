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
    public class AssignmentController : Controller
    {
        private readonly Assignment_2Context context;
        private readonly AssignmentRepository repository;

        public AssignmentController()
        {
            context = new Assignment_2Context();
            repository = new AssignmentRepository(context);
        }


        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult> Get()
        {
            var assignments = await repository.GetAll();
            if (assignments == null) return HttpNotFound("There aren't any assignments!");

            return View("AssignmentIndex", assignments);
        }

        [HttpGet]
        public async Task<ActionResult> Get(int id)
        {
            if (id == 0) return View("AssignmentForm", new Assignment(id));

            var assignment = await repository.GetById(id);
            if (assignment == null) return HttpNotFound("No assignment found!");

            return View("AssignmentForm", assignment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Post(AssignmentViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("AssignmentForm", viewModel);

            repository.CreateOrUpdate(new Assignment(viewModel));

            return RedirectToAction("Get", "Assignment");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id == 0) return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid Id!");

            repository.Delete(id);

            return RedirectToAction("Get", "Assignment");
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
    }
}