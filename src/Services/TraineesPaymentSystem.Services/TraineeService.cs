using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TraineesPaymentSystem.Data.Common.Repository;
using TraineesPaymentSystem.Data.Models;
using TraineesPaymentSystem.Services.Contracts;
using TraineesPaymentSystem.Services.Mapping;

namespace TraineesPaymentSystem.Services
{
    public class TraineeService : ITraineeService
    {
        private readonly IRepository<Trainee> traineesRepository;

        public TraineeService(IRepository<Trainee> traineesRepository)
        {
            this.traineesRepository = traineesRepository;
        }

        public async Task<ICollection<TModel>> GetAllAsync<TModel>()
        {
            var trainees = await this.traineesRepository
                .AllAsNoTracking()
                .To<TModel>()
                .ToListAsync();

            return trainees;
        }

        public async Task<int> CreateAsync<TModel>(TModel model)
        {
            var query = new EnumerableQuery<TModel>(new[] { model });
            var trainee = query.To<Trainee>().SingleOrDefault();

            await this.traineesRepository.AddAsync(trainee);
            await this.traineesRepository.SaveChangesAsync();

            // ReSharper disable once PossibleNullReferenceException
            return trainee.Id;
        }

        public Task<TModel> EditAsync<TModel>(TModel model)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TModel> GetDetailsAsync<TModel>(int id)
        {
            var trainee = await this.GetTraineeAsNoTrackingAsync<TModel>(id);

            return trainee;
        }

        private async Task<TModel> GetTraineeAsNoTrackingAsync<TModel>(int id)
        {
            var trainee = await this.traineesRepository
                .AllAsNoTracking()
                .Where(t => t.Id == id)
                .To<TModel>()
                .SingleOrDefaultAsync();

            return trainee;
        }

        private async Task<Trainee> GetTraineeAsync(int id)
        {
            var trainee = await this.traineesRepository
                .AllAsNoTracking()
                .SingleOrDefaultAsync(t => t.Id == id);

            return trainee;
        }
    }
}