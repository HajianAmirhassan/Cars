using Cars.Models;
using Cars.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cars.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet()]
        public ActionResult AboutUs()
        {
            return View();
        }
        [HttpPost()]
        public ActionResult AboutUs(string Name, string Message)
        {
            ViewBag.ShowMessage = $"{Name} -> {Message}";
            return View("ShowMessage");
        }

        public ActionResult AddCar()
        {
            return View();
        }
        [HttpPost()]
        public ActionResult AddCar(string Name , string Model , int Age)
        {
            using(DataContext context = new DataContext())
            {
                Car car = new Car() { Name = Name, Model = Model, Age = Age };

                context.cars.Add(car);

                context.SaveChanges();
            }
            return RedirectToAction("ListCar");
        }

        public ActionResult ListCar()
        {
            List<Car> cars = new List<Car>();

            using(DataContext context = new DataContext())
            {
                cars = context.cars.ToList();
            }

            return View(cars);
        }
    }
}