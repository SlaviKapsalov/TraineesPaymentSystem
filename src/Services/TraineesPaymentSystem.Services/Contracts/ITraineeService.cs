using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TraineesPaymentSystem.Services.Contracts
{
    public interface ITraineeService
    {
        /// <summary>
        /// Get all trainees
        /// </summary>
        /// <typeparam name="TModel">Output View Model</typeparam>
        /// <returns>
        /// All trainees
        /// </returns>
        Task<ICollection<TModel>> GetAllAsync<TModel>();

        /// <summary>
        /// Create Trainee
        /// </summary>
        /// <typeparam name="TModel">Input Model</typeparam>
        /// <param name="model">Input Model</param>
        /// <returns>Created trainee view model</returns>
        Task<int> CreateAsync<TModel>(TModel model);

        /// <summary>
        /// Edit Trainee
        /// </summary>
        /// <typeparam name="TModel">Input model</typeparam>
        /// <param name="model">Input model</param>
        /// <returns>Edited trainee view model</returns>
        Task<TModel> EditAsync<TModel>(TModel model);

        /// <summary>
        /// Get Trainee with given id
        /// </summary>
        /// <param name="id">Trainee id</param>
        /// <returns>
        /// Trainee View Model
        /// </returns>
        Task<TModel> GetDetailsAsync<TModel>(int id);
    }
}