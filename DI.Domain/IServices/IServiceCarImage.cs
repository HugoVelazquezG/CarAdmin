using System.Collections.Generic;
using System.Threading.Tasks;
using DI.Domain.Entity;

namespace DI.Domain.IServices
{
    public interface IServiceCarImage
    {
        Task<List<CarImage>> Get();
    }
}
