using Cars.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cars.Models.Entity
{
    public class Car
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public int Age { get; set; }

        public int Type { get; set; }

        public int CarCat_Id { get; set; }
        [ForeignKey("CarCat_Id")]
        public virtual CarCat CarCat { get; set; }

        public DateTime CreatedDate { get; set; }

        public Car()
        {
            CreatedDate = DateTime.Now;
        }
    }

}