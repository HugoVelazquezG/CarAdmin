using System.Collections.Generic;
using System.Linq;
using DI.Domain.Entity;

namespace DI.Domain.Domain
{
    public static class GetImages
    {
        public static List<CarImage> LoadCars()
        {
            List<CarImage> cars = new List<CarImage>();
            cars.AddRange(LoadCar("Ford", GetCars("Ford"), "Ford car", "Low cost sport Cars", "Sport"));
            cars.AddRange(LoadCar("Ferrari", GetCars("Ferrari"), "Ferrari car", "Elite sport Cars", "Turbo"));
            cars.AddRange(LoadCar("Nissan", GetCars("Nissan"), "Nissan car", "Oriental sport Cars", "Sport"));
            cars.AddRange(LoadCar("Toyota", GetCars("Toyota"), "Toyota car", "Electric sport Cars", "Electric"));

            return cars;
        }

        private static List<CarImage> LoadCar(string car, List<string> cars, string name, string description, string carType)
        {
            return (from res in cars
                    select new CarImage
                    {
                        
                        Name = name,
                        CarType = new CarType
                        {
                            Name = carType
                        }

                    }).ToList();
        }

        private static List<string> GetCars(string brand)
        {
            return new List<string>
            {
                brand + "1",
                brand + "2",
                brand + "3"
            };
        }
    }
}
