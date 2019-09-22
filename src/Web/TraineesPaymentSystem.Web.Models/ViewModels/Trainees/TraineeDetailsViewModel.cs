namespace TraineesPaymentSystem.Web.Models.ViewModels.Trainees
{
    using NonFactors.Mvc.Grid;
    using Services.Mapping;
    using TraineesPaymentSystem.Data.Models;

    public class TraineeDetailsViewModel : IMapFrom<Trainee>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public int Age { get; set; }

        public IGrid<TraineeTaskDetailsViewModel> Tasks { get; set; }
    }
}