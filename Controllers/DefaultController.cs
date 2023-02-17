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
        DataContext context = new DataContext();
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
        public ActionResult AddCar(string Name, string Model, int Age , int Type)
        {
            Car car = new Car() { Name = Name, Model = Model, Age = Age , Type = Type };

            context.cars.Add(car);

            context.SaveChanges();

            return RedirectToAction("ListCar");
        }

        public ActionResult ListCar()
        {
            List<Car> cars = new List<Car>();

            cars = context.cars.ToList();

            return View(cars);
        }

        public ActionResult DeleteCar(int ID)
        {
            context.cars.Remove(context.cars.Find(ID));

            context.SaveChanges();

            return RedirectToAction("ListCar");
        }

        public ActionResult EditCar(int ID)
        {
            Car car = context.cars.Find(ID);

            return View(car);
        }

        [HttpPost()]
        public ActionResult EditCar(Car car)
        {
            context.Entry(car).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();

            return RedirectToAction("ListCar");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                context.Dispose();
        }
    }
}