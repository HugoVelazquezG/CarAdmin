using System;
using System.Threading.Tasks;

namespace DI.Domain.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Creating Generic Repositories Instance
        /// </summary>
        /// <typeparam name="T">Type to apply Generic operations</typeparam>
        /// <returns>Instanced Generic</returns>
        IGenericRepository<T> Repository<T>() where T : class;

        /// <summary>
        /// Saving changes
        /// </summary>
        /// <returns>Retuns operation flag</returns>
        bool SaveContext();

        /// <summary>
        /// Saving changes async
        /// </summary>
        /// <returns>Retuns operation flag</returns>
        Task<bool> SaveContextAsync();
    }
}
