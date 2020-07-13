using PersonalEstore.cs.Models;
using PersonalEstore.cs.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalEstore.cs.Controllers
{
    public class CosmaticsController : Controller
    {
        private ApplicationDbContext _context;
        public CosmaticsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Cosmatics
        public ActionResult Index(string filters)
        {
            var cosmatics = _context.Cosmatics
                            .Include(m => m.Manufacturer)
                            .Include(c=>c.Category).ToList();
            if (filters != null)
                cosmatics = cosmatics.Where(c => c.Category.Name.Contains(filters)).ToList();

            if (User.IsInRole("isAdmin"))
                return View("AdminIndex", cosmatics);

            return View(cosmatics);
        }

        [Authorize(Roles ="isAdmin")]
        public ActionResult AddCosmatics()
        {
            var viewmodel = new CosmaticsViewModel
            {
               Cosmatics = new Cosmatics(),
               Category = _context.Category.ToList(),
               Manufacturer = _context.Manufacturer.ToList()
            };

            return View(viewmodel);
        }

        [Authorize(Roles = "isAdmin")]
        public ActionResult SaveCosmatics(HttpPostedFileBase postedFile, CosmaticsViewModel viewmodel)
        {

            var cosmatics = viewmodel.Cosmatics;
            //Getting File Name
            string fileName = System.IO.Path.GetFileName(postedFile.FileName);
            //getting extension of file
            string ext = System.IO.Path.GetExtension(postedFile.FileName);
            //setting filename with extension otherwise image will be stored as file
            fileName = cosmatics.Name + "_" + cosmatics.Id + cosmatics.ManufacturerId + ext;
            //Set the Image File Path
            string filePath = "~/image/" + fileName;
            //Save the Image File in Folder.
            postedFile.SaveAs(Server.MapPath(filePath));

            cosmatics.Image = fileName;
            if (!ModelState.IsValid)
                RedirectToAction("AddCosmatics");


            if (cosmatics.Id != 0)
            {
                var cosmaticindb = _context.Cosmatics.Single(m => m.Id == cosmatics.Id);
                if (cosmaticindb == null)
                    RedirectToAction("AddCosmatics");
                cosmaticindb.Name = cosmatics.Name;
                cosmaticindb.Price = cosmatics.Price;
                cosmaticindb.ManufacturerId = cosmatics.ManufacturerId;
                cosmaticindb.CategoryId = cosmatics.CategoryId;
                cosmaticindb.Image = cosmatics.Image;
                cosmaticindb.Stock = cosmatics.Stock;
            }
            else
            {
                cosmatics.Image = fileName;
                _context.Cosmatics.Add(cosmatics);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "isAdmin")]
        public ActionResult Edit(int id)
        {
            var cosmatics = _context.Cosmatics.Single(m => m.Id == id);
            var viewmodal = new CosmaticsViewModel
            {
                Cosmatics = cosmatics,
                Manufacturer = _context.Manufacturer.ToList(),
                Category = _context.Category.ToList()
            };

            return View("AddCosmatics", viewmodal);
        }


        public ActionResult Details(int id)
        {
            var cosmatics = _context.Cosmatics.Single(m => m.Id == id);

            cosmatics.Manufacturer = _context.Manufacturer.Single(m => m.Id == cosmatics.ManufacturerId);
            cosmatics.Category = _context.Category.Single(c => c.Id == cosmatics.CategoryId);

            return View(cosmatics);
        }

        [Authorize(Roles = "isAdmin")]
        public ActionResult Delete(int id)
        {
            var cosmatics = _context.Cosmatics.Single(m => m.Id == id);
            if (cosmatics == null)
                return HttpNotFound();

            _context.Cosmatics.Remove(cosmatics);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}