using PersonalEstore.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PersonalEstore.cs.ViewModel;

namespace PersonalEstore.cs.Controllers
{
    public class ClothingController : Controller
    {
        private ApplicationDbContext _context;
        public ClothingController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: HomeAppliances
        public ActionResult Index(string filters)
        {
            var clothing = _context.MenClothing.Include(m => m.Manufacturer)
                             .Include(c => c.Category).ToList();

            if (filters != null)
                clothing = clothing.Where(c => c.Category.Name.Contains(filters)).ToList();
            
            if(User.IsInRole("isAdmin"))
            return View("AdminIndex",clothing);

            return View(clothing);
        }

        
        [Authorize(Roles = "isAdmin")]
        public ActionResult AddClothing()
        {
            var viewmodel = new MenClothingViewModel
            {
                MenClothing = new Clothing(),
                Manufacturers = _context.Manufacturer.ToList(),
                Categories = _context.Category.ToList()
            };

            return View(viewmodel);
        }

        [HttpPost]
        [Authorize(Roles = "isAdmin")]
        public ActionResult SaveClothing(HttpPostedFileBase postedFile, MenClothingViewModel viewmodel)
        {

            var clothing = viewmodel.MenClothing;
            //Getting File Name
            string fileName = System.IO.Path.GetFileName(postedFile.FileName);
            //getting extension of file
            string ext = System.IO.Path.GetExtension(postedFile.FileName);
            //setting filename with extension otherwise image will be stored as file
            fileName = clothing.Name + "_" + clothing.Id + clothing.ManufacturerId + ext;
            //Set the Image File Path
            string filePath = "~/image/" + fileName;
            //Save the Image File in Folder.
            postedFile.SaveAs(Server.MapPath(filePath));

            clothing.Image = fileName;
            if (!ModelState.IsValid)
                RedirectToAction("AddClothing");

            //if cloth already exist than update it instead of adding it
            if (clothing.Id != 0)
            {
                var clothingindb = _context.MenClothing.Single(m => m.Id == clothing.Id);
                if (clothingindb == null)
                    RedirectToAction("AddClothing");
                clothingindb.Name = clothing.Name;
                clothingindb.Price = clothing.Price;
                clothingindb.ManufacturerId = clothing.ManufacturerId;
                clothingindb.CategoryId = clothing.CategoryId;
                clothingindb.Image = clothing.Image;
                clothingindb.Color = clothing.Color;
                clothingindb.Size = clothing.Size;
                clothingindb.Stock = clothing.Stock;
            }
            else//adding clothes to database
                _context.MenClothing.Add(clothing);

            _context.SaveChanges();

            return RedirectToAction("Index", "Clothing");
        }

        [Authorize(Roles = "isAdmin")]
        public ActionResult Edit(int id)
        {
            var clothing = _context.MenClothing.Single(m => m.Id == id);
            var viewmodal = new MenClothingViewModel
            {
                MenClothing = clothing,
                Manufacturers = _context.Manufacturer.ToList(),
                Categories = _context.Category.ToList()
            };
            return View("AddClothing", viewmodal);
        }

        public ActionResult Details(int id)
        {
            var clothing = _context.MenClothing.Single(m => m.Id == id);

            clothing.Manufacturer = _context.Manufacturer.Single(m => m.Id == clothing.ManufacturerId);
            clothing.Category = _context.Category.Single(c => c.Id == clothing.CategoryId);

            return View(clothing);
        }

        [Authorize(Roles = "isAdmin")]
        public ActionResult Delete(int id)
        {
            var clothing = _context.MenClothing.Single(m => m.Id == id);
            if (clothing == null)
                return HttpNotFound();

            _context.MenClothing.Remove(clothing);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

    }
}