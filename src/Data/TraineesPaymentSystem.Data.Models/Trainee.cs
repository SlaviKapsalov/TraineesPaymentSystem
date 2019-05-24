namespace TraineesPaymentSystem.Data.Models
{
    using System.Collections.Generic;
    using TraineesPaymentSystem.Data.Common.Models;

    // ReSharper disable VirtualMemberCallInConstructor
    public class Trainee : BaseModel<int>
    {
        public Trainee()
        {
            this.Tasks = new HashSet<TraineeTask>();
        }

        public string Name { get; set; }

        public string Username { get; set; }

        public int Age { get; set; }

        public virtual ICollection<TraineeTask> Tasks { get; set; }
    }
}