namespace TraineesPaymentSystem.Web.Models.ServiceModels
{
    using Services.Mapping;
    using System.Collections.Generic;
    using TraineesPaymentSystem.Data.Models;
    using ViewModels.Trainees;

    public class TraineeDetailsServiceModel : IMapFrom<Trainee>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public int Age { get; set; }

        public ICollection<TraineeTaskDetailsViewModel> Tasks { get; set; }
    }
}