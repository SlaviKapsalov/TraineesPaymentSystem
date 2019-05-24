using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraineesPaymentSystem.Data.Models
{
    using System.Collections.Generic;
    using TraineesPaymentSystem.Data.Common.Models;

    // ReSharper disable VirtualMemberCallInConstructor
    public class TaskType : BaseModel<int>
    {
        public TaskType()
        {
            this.Tasks = new HashSet<TraineeTask>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerHour { get; set; }

        public virtual ICollection<TraineeTask> Tasks { get; set; }
    }
}