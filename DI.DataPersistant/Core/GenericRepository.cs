using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DI.Domain.Helpers;
using DI.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DI.DataPersistant.Core
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        protected readonly DbSet<TEntity> DbSet;

        public GenericRepository(DbContext Context)
        {
            this.Context = Context;
            this.DbSet = Context.Set<TEntity>();
        }

        /// <summary>
        /// Method to gets a <see cref="List"/> of <see cref="TEntity"/>
        /// </summary>
        /// <returns><see cref="List{TEntity}"/></returns>
        public virtual async Task<List<TEntity>> Get()
        {
            return await this.Get(null, null);
        }

        /// <summary>
        /// Method to gets a <see cref="List"/> of <see cref="TEntity"/>
        /// </summary>
        /// <param name="filter">Contains a filter</param>
        /// <param name="sorting">Contains order expresion</param>
        /// <param name="order">ordering</param>
        /// <returns><see cref="List{TEntity}"/></returns>
        public virtual async Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>> sorting = null, SortOrder order = SortOrder.Ascending)
        {
            var query = this.DbSet.AsQueryable();

            if (!object.Equals(null, filter))
            {
                query = query.Where(filter);
            }

            if (!object.Equals(null, sorting))
            {
                query = query.ObjectSort(sorting, order);
            }

            return await query.ToListAsync();
        }

        /// <summary>
        /// Get number of rows
        /// </summary>
        /// <param name="filter">Contains a filter</param>
        /// <returns><see cref="int"/></returns>
        public virtual async Task<int> Count(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = this.DbSet.AsQueryable();

            if (!object.Equals(null, filter))
            {
                query = query.Where(filter);
            }

            return await query.CountAsync();
        }

        /// <summary>
        /// Method to add a register
        /// </summary>
        /// <param name="item"><see cref="TEntity"/> to Insert</param>
        public virtual void Add(TEntity item)
        {
            this.DbSet.Add(item);
        }
    }
}
