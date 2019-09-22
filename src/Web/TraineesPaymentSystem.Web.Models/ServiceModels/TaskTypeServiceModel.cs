namespace TraineesPaymentSystem.Web.Models.ServiceModels
{
    using Services.Mapping;
    using TraineesPaymentSystem.Data.Models;

    public class TaskTypeServiceModel : IMapFrom<TaskType>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal PricePerHour { get; set; }
    }
}