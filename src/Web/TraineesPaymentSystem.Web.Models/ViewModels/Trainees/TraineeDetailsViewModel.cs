using System.Collections;
using System.Collections.Generic;
using TraineesPaymentSystem.Data.Models;
using TraineesPaymentSystem.Services.Mapping;

namespace TraineesPaymentSystem.Web.Models.ViewModels.Trainees
{

    public class TraineeDetailsViewModel : IMapFrom<Trainee>
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public int Age { get; set; }

        public ICollection<TraineeTaskDetailsViewModel> Tasks { get; set; }
    }
}