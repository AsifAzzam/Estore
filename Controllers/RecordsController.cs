using PersonalEstore.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PersonalEstore.cs.Controllers
{
    public class RecordsController : Controller
    {
        private ApplicationDbContext _context;
        public RecordsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Records
        public ActionResult MobilePhones(string filter)
        {
            var phones = _context.MobilePhones
                        .Include(m=>m.Manufacturer)
                        .Include(c=>c.Category)
                        .Where(phone=>phone.Category.Name.Contains(filter));
            return RedirectToAction("Index","Home",phones);
        }

        public ActionResult clothes(string filters)
        {
            return View();
        }

        public ActionResult homeAppliances(string filters)
        {
            return View();
        }
    }
}