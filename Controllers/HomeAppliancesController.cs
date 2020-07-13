using PersonalEstore.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PersonalEstore.cs.ViewModel;
using Z.EntityFramework.Plus;

namespace PersonalEstore.cs.Controllers
{
    public class HomeAppliancesController : Controller
    {
        private ApplicationDbContext _context;
        public HomeAppliancesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: HomeAppliances
        public ActionResult Index(string filters)
        {

            var appliances = _context.HomeAppliances.Include(m => m.Manufacturer)
                             .Include(c => c.Category).ToList();

            if (filters != null)
                appliances = appliances.Where(a => a.Category.Name.Contains(filters)).ToList();

            if (User.IsInRole("isAdmin"))
                return View("AdminIndex", appliances);

            return View(appliances);
        }

        [Authorize(Roles = "isAdmin")]
        public ActionResult AddAppliances()
        {
            var viewmodel = new AppliancesViewModel
            {
                Appliances = new HomeAppliances(),
                Manufacturers = _context.Manufacturer.ToList(),
                Categories = _context.Category.ToList()
            };

            return View(viewmodel);
        }

        [HttpPost]
        [Authorize(Roles = "isAdmin")]
        public ActionResult SaveAppliances(HttpPostedFileBase postedFile, AppliancesViewModel viewmodel)
        {

            var appliances = viewmodel.Appliances;
            //Getting File Name
            string fileName = System.IO.Path.GetFileName(postedFile.FileName);
            //getting extension of file
            string ext = System.IO.Path.GetExtension(postedFile.FileName);
            //setting filename with extension otherwise image will be stored as file
            fileName = appliances.Name + "_" + appliances.Id + appliances.ManufacturerId + ext;
            //Set the Image File Path
            string filePath = "~/image/" + fileName;
            //Save the Image File in Folder.
            postedFile.SaveAs(Server.MapPath(filePath));

            appliances.Image = fileName;
            if (!ModelState.IsValid)
                RedirectToAction("AddAppliances");


            if (appliances.Id != 0)
            {
                var appliancesindb = _context.HomeAppliances.Single(m => m.Id == appliances.Id);
                if (appliancesindb == null)
                    RedirectToAction("AddAppliances");
                appliancesindb.Name = appliances.Name;
                appliancesindb.Price = appliances.Price;
                appliancesindb.Manufacturer = appliances.Manufacturer;
                appliancesindb.Display = appliances.Display;
                appliancesindb.Colors = appliances.Colors;
                appliancesindb.ManufacturerId = appliances.ManufacturerId;
                appliancesindb.CategoryId = appliances.CategoryId;
                appliancesindb.Image = appliances.Image;
                appliancesindb.Stock = appliances.Stock;
            }
            else
                _context.HomeAppliances.Add(appliances);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "isAdmin")]
        public ActionResult Edit(int id)
        {
            var appliances = _context.HomeAppliances.Single(m => m.Id == id);
            var viewmodal = new AppliancesViewModel
            {
                Appliances = appliances,
                Manufacturers = _context.Manufacturer.ToList(),
                Categories = _context.Category.ToList()
            };
            return View("AddAppliances", viewmodal);
        }

        public ActionResult Details(int id)
        {
            
            var appliances = _context.HomeAppliances
                .Single(m => m.Id == id);

            appliances.Manufacturer = _context.Manufacturer.Single(m => m.Id == appliances.ManufacturerId);
            appliances.Category = _context.Category.Single(c => c.Id == appliances.CategoryId);

            return View(appliances);
        }

        [Authorize(Roles = "isAdmin")]
        public ActionResult Delete(int id)
        {
            var appliances = _context.HomeAppliances.Single(m => m.Id == id);
            if (appliances == null)
                return HttpNotFound();

            _context.HomeAppliances.Remove(appliances);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}