namespace TraineesPaymentSystem.Services
{
    using Contracts;
    using Data.Common.Repository;
    using Data.Models;
    using Mapping;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TaskTypeService : ITaskTypeService
    {
        private readonly IRepository<TaskType> typeRepository;

        public TaskTypeService(IRepository<TaskType> typeRepository)
        {
            this.typeRepository = typeRepository;
        }

        public async Task<ICollection<TModel>> GetAllAsync<TModel>()
        {
            var types = await this.typeRepository
                .AllAsNoTracking()
                .To<TModel>()
                .ToListAsync();

            return types;
        }
    }
}