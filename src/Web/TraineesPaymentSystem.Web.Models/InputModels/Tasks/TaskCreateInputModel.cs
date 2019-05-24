namespace TraineesPaymentSystem.Web.Models.InputModels.Tasks
{
    using Services.Mapping;
    using System;
    using System.ComponentModel.DataAnnotations;
    using TraineesPaymentSystem.Data.Models;

    public class TaskCreateInputModel : IMapTo<TraineeTask>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Hours { get; set; }

        public string Comment { get; set; }

        [Required]
        public DateTime FinishedOn { get; set; }

        [Required]
        public string AssignedFrom { get; set; }

        [Required]
        public int TraineeId { get; set; }

        [Required]
        public int TypeId { get; set; }
    }
}