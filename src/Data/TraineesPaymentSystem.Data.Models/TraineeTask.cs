using System;
using System.ComponentModel.DataAnnotations;
using TraineesPaymentSystem.Data.Common.Models;

namespace TraineesPaymentSystem.Data.Models
{
    public class TraineeTask : BaseModel<int>
    {
        [Required]
        public string Name { get; set; }

        // course

        [Required]
        public int Hours { get; set; }

        public string Comment { get; set; }

        [Required]
        public DateTime FinishedOn { get; set; }

        [Required]
        public string AssignedFrom { get; set; }

        [Required]
        public int TraineeId { get; set; }

        public virtual Trainee Trainee { get; set; }

        [Required]
        public int TypeId { get; set; }

        public virtual TaskType Type { get; set; }
    }
}