using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using TraineesPaymentSystem.Web.Models.ServiceModels;
using TraineesPaymentSystem.Web.Models.ViewModels.Tasks;

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
        private readonly ITaskTypeService taskTypeService;

        public TasksController(ITaskService taskService, ITaskTypeService taskTypeService)
        {
            this.taskService = taskService;
            this.taskTypeService = taskTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int traineeId)
        {

            this.ViewData["TraineeId"] = traineeId;
            var types = await this.GetAllTaskTypes();
            this.ViewData["TaskTypes"] = types;
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

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var task = await this.taskService.Details<TaskDetailsViewModel>((int)id);

            if (task == null)
            {
                var controller = ControllerHelper.GetControllerName(nameof(TraineesController));
                return this.RedirectToAction(nameof(TraineesController.Index), controller);
            }

            return this.View(task);
        }

        private async Task<ICollection<SelectListItem>> GetAllTaskTypes()
        {
            var taskTypes = await this.taskTypeService.GetAllAsync<TaskTypeServiceModel>();

            var types = new List<SelectListItem>();

            foreach (var type in taskTypes)
            {
                types.Add(new SelectListItem(type.Name, type.Id.ToString()));
            }

            return types;
        }
    }
}