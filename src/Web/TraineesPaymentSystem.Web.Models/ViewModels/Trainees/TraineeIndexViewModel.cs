namespace TraineesPaymentSystem.Web.Models.ViewModels.Trainees
{
    using AutoMapper;
    using TraineesPaymentSystem.Data.Models;
    using TraineesPaymentSystem.Services.Mapping;

    public class TraineeIndexViewModel : IMapFrom<Trainee>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public int Age { get; set; }

        public int CountTasks { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {

            configuration.CreateMap<Trainee, TraineeIndexViewModel>()
                .ForMember(dto => dto.CountTasks, opt => opt.MapFrom(t => t.Tasks.Count));
        }
    }
}