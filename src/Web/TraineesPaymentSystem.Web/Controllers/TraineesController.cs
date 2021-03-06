﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NonFactors.Mvc.Grid;
using TraineesPaymentSystem.Common;
using TraineesPaymentSystem.Data.Models;
using TraineesPaymentSystem.Services.Contracts;
using TraineesPaymentSystem.Web.Models.InputModels;
using TraineesPaymentSystem.Web.Models.ServiceModels;
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
            var traineesGrid = await this.CreateExportableTraineesGrid();

            if (traineesGrid == null)
            {
                var controllerName = ControllerHelper.GetControllerName(nameof(HomeController));
                return this.RedirectToAction(nameof(HomeController.Index), controllerName);
            }

            return this.View(traineesGrid);
        }

        [HttpGet]
        public async Task<IActionResult> ExportIndex()
        {
            IGrid<TraineeIndexViewModel> grid = await this.CreateExportableTraineesGrid();

            int col = 0;
            int row = 0;
            foreach (IGridRow<TraineeIndexViewModel> gridRow in grid.Rows)
            {
                col = 1;
                foreach (IGridColumn column in grid.Columns)
                    Console.Write(column.ValueFor(gridRow) + "      ");

                row++;
                Console.WriteLine();
            }

            return this.RedirectToAction(nameof(this.Index));
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

            var traineeServiceModel = await this.traineeService.GetDetailsAsync<TraineeDetailsServiceModel>((int)id);

            if (traineeServiceModel == null)
            {
                return this.NotFound();
            }

            var tasks = await this.CreateExportableTraineeTasksGrid(traineeServiceModel.Tasks);

            var trainee = new TraineeDetailsViewModel
            {
                Id =  traineeServiceModel.Id,
                Username =  traineeServiceModel.Username,
                Age = traineeServiceModel.Age,
                Name = traineeServiceModel.Name,
                Tasks = tasks
            };

            return this.View(trainee);
        }

        private async Task<IGrid<TraineeIndexViewModel>> CreateExportableTraineesGrid()
        {
            var trainees = await this.traineeService.GetAllAsync<TraineeIndexViewModel>();

            if (trainees == null)
            {
                return null;
            }

            IGrid<TraineeIndexViewModel> grid = new Grid<TraineeIndexViewModel>(trainees);

            grid.ViewContext = new ViewContext { HttpContext = this.HttpContext };
            grid.Query = this.Request.Query;

            grid.Columns.Add(model => $@"<a href=""/Trainees/Details/{model.Id}"">{model.Name}</a>").Titled("Name").Encoded(false);
            grid.Columns.Add(model => model.Username).Titled("Username");
            grid.Columns.Add(model => model.Age).Titled("Age");

            grid.Columns.Add(model => model.CountTasks).Titled("Count Tasks");

            grid.Pager = new GridPager<TraineeIndexViewModel>(grid);
            grid.Processors.Add(grid.Pager);
            grid.Pager.RowsPerPage = 6;

            foreach (IGridColumn column in grid.Columns)
            {
                column.Filter.IsEnabled = true;
                column.Sort.IsEnabled = true;
            }

            return grid;
        }

        private async Task<IGrid<TraineeTaskDetailsViewModel>> CreateExportableTraineeTasksGrid(
            ICollection<TraineeTaskDetailsViewModel> tasks)
        {
            if (tasks == null)
            {
                return null;
            }

            IGrid<TraineeTaskDetailsViewModel> grid = new Grid<TraineeTaskDetailsViewModel>(tasks);

            grid.ViewContext = new ViewContext { HttpContext = this.HttpContext };
            grid.Query = this.Request.Query;

            grid.Columns.Add(model => $@"<a href=""/Tasks/Details/{model.Id}"">{model.Name}</a>").Titled("Name").Encoded(false);
            grid.Columns.Add(model => model.TypeName).Titled("Type");
            grid.Columns.Add(model => model.Hours).Titled("Hours");

            grid.Columns.Add(model => model.AssignedFrom).Titled("Assigned From");
            grid.Columns.Add(model => model.FinishedOn).Titled("Finished On").Formatted("{0:d}");

            grid.Pager = new GridPager<TraineeTaskDetailsViewModel>(grid);
            grid.Processors.Add(grid.Pager);
            grid.Pager.RowsPerPage = 6;

            foreach (IGridColumn column in grid.Columns)
            {
                column.Filter.IsEnabled = true;
                column.Sort.IsEnabled = true;
            }

            return grid;
        }
    }
}