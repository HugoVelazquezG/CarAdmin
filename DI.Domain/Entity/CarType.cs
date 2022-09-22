using System;
using System.Collections.Generic;
using System.Text;

namespace DI.Domain.Entity
{
    public class CarType
    {
        public int CarTypeId { get; set; }
        public string Name { get; set; }
        public virtual List<CarImage> CarImages { get; set; }
    }
}
