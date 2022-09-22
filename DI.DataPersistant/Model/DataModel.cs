using System;
using System.Collections.Generic;
using System.Text;
using DI.Domain.Entity;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace DI.DataPersistant.Model
{
    public class DataModel : DbContext
    {
        public DbSet<CarImage> CarImage { get; set; }
        public DbSet<CarType> CarType { get; set; }


        public DataModel(DbContextOptions options) : base(options)
        {
            
        }
    }
}
