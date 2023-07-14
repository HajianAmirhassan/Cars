using Cars.Models;
using Cars.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cars.Areas.AdminPanel.Controllers
{
    public class CarController : Controller
    {
        // GET: AdminPanel/Car
        DataContext context = new DataContext();
        public ActionResult Index()
        {
            List<Car> cars = new List<Car>();

            cars = context.cars.ToList();

            return View(cars);
        }

        public ActionResult AddCar()
        {
            ViewBag.CarCat = context.CarCats.ToList();

            return View();
        }
        [HttpPost()]
        public ActionResult AddCar(Car car, HttpPostedFileBase url)
        {
            if (url != null)
            {
                string fileurl = "/Upload/Car/" + Guid.NewGuid().ToString().Substring(0, 6) + "_" + url.FileName;

                url.SaveAs(Server.MapPath("~" + fileurl));

                car.ImageUrl = fileurl;
            }
            context.cars.Add(car);

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteCar(int ID)
        {
            FileInfo file = new FileInfo(Server.MapPath("~" + context.cars.Find(ID).ImageUrl));

            if (file.Exists)

                file.Delete();

            context.cars.Remove(context.cars.Find(ID));

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult EditCar(int ID)
        {
            ViewBag.CarCat = context.CarCats.ToList();

            Car car = context.cars.Find(ID);

            return View(car);
        }

        [HttpPost()]
        public ActionResult EditCar(Car car, HttpPostedFileBase url)
        {
            if (url != null)
            {
                FileInfo file = new FileInfo(Server.MapPath("~" + context.cars.Find(car.Id).ImageUrl));

                if (file.Exists)

                    file.Delete();

                string fileurl = "/Upload/Car/" + Guid.NewGuid().ToString().Substring(0, 6) + "_" + url.FileName;

                url.SaveAs(Server.MapPath("~" + fileurl));

                car.ImageUrl = fileurl;
            }
            context.Entry(car).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();

            return RedirectToAction("Index");
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