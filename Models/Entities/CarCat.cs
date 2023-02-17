using Cars.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cars.Models.Entities
{
    public class CarCat
    {
        public int id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Car> CarCollection { get; set; }

        public CarCat()
        {
            CarCollection = new List<Car>();
        }
    }
}