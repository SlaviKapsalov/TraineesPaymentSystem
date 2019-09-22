namespace TraineesPaymentSystem.Web.Models.InputModels
{
    using Services.Mapping;
    using System.ComponentModel.DataAnnotations;
    using TraineesPaymentSystem.Data.Models;

    public class TraineeCreateInputModel : IMapTo<Trainee>
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        public string Username { get; set; }

        [Required]
        public int Age { get; set; }
    }
}