using PersonalEstore.cs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalEstore.cs.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            
            var phones = _context.MobilePhones
                        .Include(m=>m.Manufacturer)
                        .Include(c=>c.Category)
                        .ToList();
           
            return View(phones);
        }
        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}