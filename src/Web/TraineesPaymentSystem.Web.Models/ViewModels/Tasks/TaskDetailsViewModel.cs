using System;
using TraineesPaymentSystem.Data.Models;
using TraineesPaymentSystem.Services.Mapping;

namespace TraineesPaymentSystem.Web.Models.ViewModels.Tasks
{
    public class TaskDetailsViewModel : IMapFrom<TraineeTask>
    {
        public string Name { get; set; }

        public int Hours { get; set; }

        public string Comment { get; set; }

        public DateTime FinishedOn { get; set; }

        public string AssignedFrom { get; set; }

        public int TraineeId { get; set; }

        public string TraineeName { get; set; }

        public int TypeId { get; set; }

        public string TypeName { get; set; }
    }
}