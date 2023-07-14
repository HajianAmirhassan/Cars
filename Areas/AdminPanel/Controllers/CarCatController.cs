using Cars.Models;
using Cars.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cars.Areas.AdminPanel.Controllers
{
    public class CarCatController : Controller
    {
        DataContext Context = new DataContext();

        // GET: AdminPanel/CarCat
        public ActionResult Index()
        {
            List<CarCat> carCats = Context.CarCats.ToList();
            return View(carCats);
        }

        public ActionResult AddCat()
        {
            return View();
        }
        [HttpPost()]
        public ActionResult AddCat(CarCat cat)
        {
            Context.CarCats.Add(cat);

            Context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult EditCat(int id)
        {
            CarCat cat = Context.CarCats.Find(id);
            return View(cat);
        }
        [HttpPost()]
        public ActionResult EditCat(CarCat cat)
        {
            Context.Entry(cat).State = System.Data.Entity.EntityState.Modified;

            Context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteCat(int id)
        {
            Context.CarCats.Remove(Context.CarCats.Find(id));

            Context.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
                base.Dispose(disposing);
            }
        }
    }
}