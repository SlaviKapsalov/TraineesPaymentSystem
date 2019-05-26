using Microsoft.EntityFrameworkCore;

namespace TraineesPaymentSystem.Services
{
    using Contracts;
    using Data.Common.Repository;
    using Data.Models;
    using Mapping;
    using System.Linq;
    using System.Threading.Tasks;

    public class TaskService : ITaskService
    {
        private readonly IRepository<TraineeTask> taskRepository;

        public TaskService(IRepository<TraineeTask> taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public async Task<int> Create<TModel>(TModel model)
        {
            var query = new EnumerableQuery<TModel>(new[] {model});
            var task = query.To<TraineeTask>().SingleOrDefault();

            await this.taskRepository.AddAsync(task);
            await this.taskRepository.SaveChangesAsync();

            // ReSharper disable once PossibleNullReferenceException
            return task.Id;
        }

        public async Task<TModel> Details<TModel>(int id)
        {
            var task = await this.taskRepository
                .AllAsNoTracking()
                .Where(t => t.Id == id)
                .To<TModel>()
                .SingleOrDefaultAsync();

            return task;
        }
    }
}