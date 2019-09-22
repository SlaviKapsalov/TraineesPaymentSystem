namespace TraineesPaymentSystem.Web.Models.ViewModels.Trainees
{
    using Services.Mapping;
    using System;
    using TraineesPaymentSystem.Data.Models;

    public class TraineeTaskDetailsViewModel : IMapFrom<TraineeTask>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Hours { get; set; }

        //public string Comment { get; set; }

        public DateTime FinishedOn { get; set; }

        public string AssignedFrom { get; set; }

        public int TypeId { get; set; }

        public string TypeName { get; set; }
    }
}