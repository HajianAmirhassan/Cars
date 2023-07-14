using Cars.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cars.Models
{
    public class DataContext:DbContext
    {
        public DbSet<Car> cars { get; set; }

        public DbSet<CarCat> CarCats { get; set; }

        public DataContext():base("MyConnectionString")
        {
            
        }
    }
}