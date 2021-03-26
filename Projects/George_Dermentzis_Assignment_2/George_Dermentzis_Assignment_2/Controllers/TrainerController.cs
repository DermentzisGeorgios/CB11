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
    public class TrainerController : Controller
    {
        private readonly Assignment_2Context context;
        private readonly TrainerRepository repository;

        public TrainerController()
        {
            context = new Assignment_2Context();
            repository = new TrainerRepository(context);
        }


        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult> Get()
        {
            var trainers = await repository.GetAll();
            if (trainers == null) return HttpNotFound("There aren't any trainers!");

            return View("TrainerIndex", trainers);
        }

        [HttpGet]
        public async Task<ActionResult> Get(int id)
        {
            if (id == 0) return View("TrainerForm", new Trainer(id));

            var trainer = await repository.GetById(id);
            if (trainer == null) return HttpNotFound("No trainer found!");

            return View("TrainerForm", trainer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Post(TrainerViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("TrainerForm", viewModel);

            repository.CreateOrUpdate(new Trainer(viewModel));

            return RedirectToAction("Get", "Trainer");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id == 0) return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid Id!");

            repository.Delete(id);

            return RedirectToAction("Get", "Trainer");
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
    }
}