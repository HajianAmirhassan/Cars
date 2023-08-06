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
    public class DefaultController : Controller
    {
        DataContext context = new DataContext();
        // GET: AdminPanel/Default
        public ActionResult Index()
        {
            Setting setting = new Setting() { Title = "Default title" };

            List<string> list = new List<string>();

            foreach (string item in Directory.GetFiles(Server.MapPath("/Views/Shared/")))
            {
                FileInfo file = new FileInfo(item);
                list.Add(file.Name);
            }

            ViewBag.layout = list;

            try
            {
                setting = context.Settings.First();
            }
            catch (Exception ex)
            {
                context.Settings.Add(setting);
                context.SaveChanges();
            }
            return View(setting);
        }
        [HttpPost()]
        public ActionResult Index(Setting setting)
        {
            List<string> list = new List<string>();

            foreach (string item in Directory.GetFiles(Server.MapPath("/Views/Shared/")))
            {
                FileInfo file = new FileInfo(item);
                list.Add(file.Name);
            }

            ViewBag.layout = list;

            context.Entry(setting).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();

            return View(setting);
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