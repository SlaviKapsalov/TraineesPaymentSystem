using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TraineesPaymentSystem.Common;
using TraineesPaymentSystem.Services.Contracts;
using TraineesPaymentSystem.Web.Models.InputModels;
using TraineesPaymentSystem.Web.Models.ViewModels.Trainees;

namespace TraineesPaymentSystem.Web.Controllers
{
    public class TraineesController : BaseController
    {
        private readonly ITraineeService traineeService;

        public TraineesController(ITraineeService traineeService)
        {
            this.traineeService = traineeService;
        }


        public async Task<IActionResult> Index()
        {
            var trainees = await this.traineeService.GetAllAsync<TraineeIndexViewModel>();

            if (trainees == null)
            {
                var controllerName = ControllerHelper.GetControllerName(nameof(HomeController));
                return this.RedirectToAction(nameof(HomeController.Index), controllerName);
            }

            return this.View(trainees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TraineeCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var id = await this.traineeService.CreateAsync(model);


            return this.RedirectToAction(nameof(this.Details), id);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var trainee = await this.traineeService.GetDetailsAsync<TraineeDetailsViewModel>((int)id);

            if (trainee == null)
            {
                return this.NotFound();
            }

            return this.View(trainee);
        }
    }
}