using Cars.Models;
using Cars.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cars.Models.Entities;


namespace Cars.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public HomeController()
        {
            ViewBag.Layout = context.Settings.First().Layout;
        }

        DataContext context = new DataContext();

        public ActionResult Index()
        {
            List<Car> car = context.cars.ToList();

            return View(car);
        }
        public ActionResult CarList(int id)
        {
            List<Car> car = context.cars.Where(it => it.CarCat_Id == id).ToList();

            return View(car);
        }
        public ActionResult CarCat()
        {
            List<CarCat> cat = context.CarCats.ToList();

            return View(cat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
                base.Dispose(disposing);
            }
        }
    }
}