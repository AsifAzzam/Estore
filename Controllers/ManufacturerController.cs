using PersonalEstore.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalEstore.cs.Controllers
{
    public class ManufacturerController : Controller
    {
        private ApplicationDbContext _context;

        public ManufacturerController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Manufacturer
        public ActionResult Index()
        {
            var manuf = _context.Manufacturer.ToList();
            return View(manuf);
        }

        public ActionResult AddManufacturer()
        {
            var model = new Manufacturer();
            return View(model);
        }

        public ActionResult SaveManufacturer(Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
                RedirectToAction("AddManufacturer");

            if (manufacturer.Id != 0)
            {
                var manufindb = _context.Manufacturer
                                .Single(m => m.Id == manufacturer.Id);
                if(manufindb == null)
                    RedirectToAction("AddManufacturer");

                manufindb.Name = manufacturer.Name;
                manufindb.Address = manufacturer.Address;
                manufindb.ContactNo = manufacturer.ContactNo;
                manufindb.Email = manufacturer.Email;
            }
            else
                _context.Manufacturer.Add(manufacturer);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var manuf = _context.Manufacturer.Single(m=>m.Id==id);
            if (manuf == null)
                return View("Index");
            _context.Manufacturer.Remove(manuf);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var manuf = _context.Manufacturer.Single(m => m.Id == id);
            if (manuf == null)
                return View("Index");

            return View("AddManufacturer", manuf);

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}