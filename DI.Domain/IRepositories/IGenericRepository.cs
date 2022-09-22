using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DI.Domain.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Method to gets a <see cref="List"/> of <see cref="TEntity"/>
        /// </summary>
        /// <returns><see cref="List{TEntity}"/></returns>
        Task<List<TEntity>> Get();

        /// <summary>
        /// Method to gets a <see cref="List"/> of <see cref="TEntity"/>
        /// </summary>
        /// <param name="filter">Contains a filter</param>
        /// <param name="sorting">Contains order expresion</param>
        /// <param name="order">ordering</param>
        /// <returns><see cref="List{TEntity}"/></returns>
        Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>> sorting = null, SortOrder order = SortOrder.Ascending);

        /// <summary>
        /// Get number of rows
        /// </summary>
        /// <param name="filter">Contains a filter</param>
        /// <returns><see cref="int"/></returns>
        Task<int> Count(Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Method to add a register
        /// </summary>
        /// <param name="item"><see cref="TEntity"/> to Insert</param>
        void Add(TEntity item);

    }
}
