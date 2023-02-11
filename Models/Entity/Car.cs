using System;
using System.Collections.Generic;
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

        public DateTime CreatedDate { get; set; }


    }
}