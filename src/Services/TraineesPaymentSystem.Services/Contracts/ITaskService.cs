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
    }
}