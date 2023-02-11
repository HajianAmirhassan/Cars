using Cars.Models.Entity;
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

        public DataContext()
        {
            Database.Connection.ConnectionString = "server=.;database=Cars;trusted_connection = true";
        }
    }
}