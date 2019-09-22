using System.Collections.Generic;
using System.Threading.Tasks;

namespace TraineesPaymentSystem.Services.Contracts
{
    public interface ITaskTypeService
    {
        /// <summary>
        /// Get All Task Types
        /// </summary>
        /// <typeparam name="TModel">View Model</typeparam>
        /// <returns>
        /// All Task Types
        /// </returns>
        Task<ICollection<TModel>> GetAllAsync<TModel>();
    }
}