using System;
using System.Collections.Generic;
using System.Text;

namespace DI.Domain.Entity
{
    public class CarImage
    {
        public int CarImageId { get; set; }
        public string Name { get; set; }

        public int CarTypeId { get; set; }
        public CarType CarType { get; set; }
    }
}
