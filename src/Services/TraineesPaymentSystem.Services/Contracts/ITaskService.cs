using System.Threading.Tasks;

namespace TraineesPaymentSystem.Services.Contracts
{
    public interface ITaskService
    {
        /// <summary>
        /// Add Trainee's Task
        /// </summary>
        /// <typeparam name="TModel">Input Model</typeparam>
        /// <param name="model">Input Model</param>
        /// <returns></returns>
        Task<int> Create<TModel>(TModel model);

        /// <summary>
        /// Get Task Details
        /// </summary>
        /// <typeparam name="TModel">View Model</typeparam>
        /// <param name="id">Task Id</param>
        /// <returns>
        /// Task  Details
        /// </returns>
        Task<TModel> Details<TModel>(int id);
    }
}