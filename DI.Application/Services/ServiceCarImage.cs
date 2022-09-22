using System.Collections.Generic;
using System.Threading.Tasks;
using DI.Domain.Entity;
using DI.Domain.IRepositories;
using DI.Domain.IServices;

namespace DI.Application.Services
{
    public class ServiceCarImage : IServiceCarImage
    {
        private IUnitOfWork UnitOfWork;

        public ServiceCarImage(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public async Task<List<CarImage>> Get()
        {
            return await this.UnitOfWork.Repository<CarImage>().Get();
        }
    }
}
