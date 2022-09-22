using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DI.DataPersistant.Model;
using DI.Domain.IRepositories;

namespace DI.DataPersistant.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// DataModel Context
        /// </summary>
        public readonly DataModel Context;

        /// <summary>
        /// Dictionary To create generic Repository instances
        /// </summary>
        private Dictionary<string, object> repositories;

        /// <summary>
        /// Unit of Work Contructor
        /// </summary>
        /// <param name="Context"><see cref="DataModel"/> Context</param>
        public UnitOfWork(DataModel Context)
        {
            this.Context = Context;
        }

        /// <summary>
        /// Creating Generic Repositories Instance
        /// </summary>
        /// <typeparam name="T">Type to apply Generic operations</typeparam>
        /// <returns>Instanced Generic</returns>
        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (object.Equals(null, repositories))
            {
                this.repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!this.repositories.ContainsKey(type))
            {
                var repositoryInstance = Activator.CreateInstance(typeof(GenericRepository<T>), new object[] { this.Context });
                repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<T>)this.repositories[type];
        }

        /// <summary>
        /// Saving changes
        /// </summary>
        /// <returns>Retuns operation flag</returns>
        public bool SaveContext()
        {
            return this.Context.SaveChanges() > 0;
        }

        /// <summary>
        /// Saving changes async
        /// </summary>
        /// <returns>Retuns operation flag</returns>
        public async Task<bool> SaveContextAsync()
        {
            return await this.Context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
