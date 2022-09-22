using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DI.Domain.Domain;
using DI.Domain.Entity;
using DI.Domain.IRepositories;
using DI.Domain.IServices;

namespace DI.Application.Services
{
    public class ServiceLoadInformation : IServiceLoadInformation
    {
        /// <summary>
        /// Unit Of work interface
        /// </summary>
        private readonly IUnitOfWork UnitOfWork;

        /// <summary>
        /// Unit Of work constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        public ServiceLoadInformation(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// method to add initial information
        /// </summary>
        /// <returns>returns Flag work</returns>
        public async Task<bool> LoadInitialInformation()
        {
            var rows = await this.UnitOfWork.Repository<CarImage>().Count();
            List<CarImage> carsFormated = new List<CarImage>();
            CarImage carFormated = new CarImage();

            if (rows <= 0)
            {
                List<CarImage> cars = GetImages.LoadCars();
                foreach (var item in cars)
                {
                    carFormated = new CarImage
                    {
                        Name = item.Name,
                        CarTypeId = await this.AddType(item.CarType)
                    };

                    carsFormated.Add(carFormated);

                    this.AddCarImage(carFormated);

                    this.UnitOfWork.SaveContext();
                }
            }
            return await Task.FromResult(true);
        }

        /// <summary>
        /// Metheod To add Brands
        /// </summary>
        /// <param name="carType"><see cref="CarType"/> Object</param>
        /// <returns>Car Type Id</returns>
        private async Task<int> AddType(CarType carType)
        {
            var count = await this.UnitOfWork.Repository<CarType>().Count(c => c.Name == carType.Name);

            if (count <= 0)
            {
                this.UnitOfWork.Repository<CarType>().Add(carType);
            }
            else
                carType = (await this.UnitOfWork.Repository<CarType>().Get(c => c.Name == carType.Name)).SingleOrDefault();

            return carType.CarTypeId;
        }

        /// <summary>
        /// Metheod To add Car images
        /// </summary>
        /// <param name="carImage"><see cref="CarType"/> Object</param>
        /// <returns>Insert Flag</returns>
        private void AddCarImage(CarImage carImage)
        {
            this.UnitOfWork.Repository<CarImage>().Add(carImage);
        }
    }
}
