using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DI.Domain.Entity;

namespace DI.Domain.IServices
{
    public interface IServiceLoadInformation
    {
        /// <summary>
        /// method to add initial information
        /// </summary>
        /// <returns>returns Flag work</returns>
        Task<bool> LoadInitialInformation();
    }
}
