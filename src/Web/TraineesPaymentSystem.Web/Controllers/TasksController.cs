namespace TraineesPaymentSystem.Web.Controllers
{
    using Common;
    using Microsoft.AspNetCore.Mvc;
    using Models.InputModels.Tasks;
    using Services.Contracts;
    using System.Threading.Tasks;

    public class TasksController : BaseController
    {
        private readonly ITaskService taskService;

        public TasksController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var traineeId = await this.taskService.Create(model);

            var controller = ControllerHelper.GetControllerName(nameof(TraineesController));
            return this.RedirectToAction(nameof(TraineesController.Details), controller, new { id = traineeId });
        }
    }
}