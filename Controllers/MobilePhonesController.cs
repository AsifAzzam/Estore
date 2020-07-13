using PersonalEstore.cs.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalEstore.cs.ViewModel;
using System.Drawing;
using System.IO;
using System.Data.Entity.Validation;

namespace PersonalEstore.cs.Controllers
{
    public class MobilePhonesController : Controller
    {
        private ApplicationDbContext _context;
        public MobilePhonesController()
        {
            _context = new ApplicationDbContext();
        }

       

        // GET: MobilePhones 
        public ActionResult Index(string filters)
        {
            
            var phones = _context.MobilePhones
                       .Include(m => m.Manufacturer)
                       .Include(c => c.Category)
                       .ToList();
            //for filtering on the base of category
            if (filters != null)
                phones = _context.MobilePhones
                           .Include(m => m.Manufacturer)
                           .Include(c => c.Category)
                           .Where(p => p.Category.Name.Contains(filters))
                           .ToList();
            //if logged in user is admin then return admin view 
            if (User.IsInRole("isAdmin"))
                return View("Adminindex", phones);

            return View("Index",phones);
        }

        //render view for adding mobile phone and is only available for admin 
        [Authorize(Roles = "isAdmin")]
        public ActionResult AddMobile()
        {
            var viewmodel = new MobileManufViewModel
            {
                MobilePhone = new MobilePhones(),
                Manufacturer = _context.Manufacturer.ToList(),
                Category = _context.Category.ToList()
            };

            return View(viewmodel);
        }

        //save a mobilephone to database
        [HttpPost]
        [Authorize(Roles ="isAdmin")]
        public ActionResult SaveMobile(HttpPostedFileBase postedFile,MobileManufViewModel viewmodel)
        {

            var phone = viewmodel.MobilePhone;
            //Getting File Name
            string fileName = System.IO.Path.GetFileName(postedFile.FileName);
            //getting extension of file
            string ext = System.IO.Path.GetExtension(postedFile.FileName);
            //setting filename with extension otherwise image will be stored as file
            fileName = phone.Name +"_"+ phone.Id + phone.ManufacturerId + ext;
            //Set the Image File Path
            string filePath = "~/image/" + fileName;
            //Save the Image File in Folder.
            postedFile.SaveAs(Server.MapPath(filePath));

            phone.Image = fileName;
            //checking for valid model
            if (!ModelState.IsValid)
                RedirectToAction ("AddMobile");

            //if phone id is not equal to zero it means we are updating an 
            //existing phone
            if (phone.Id != 0)
            {
                var phoneindb = _context.MobilePhones.Single(m => m.Id == phone.Id);
                if (phoneindb == null)
                    RedirectToAction("AddMobile");
                phoneindb.Name = phone.Name;
                phoneindb.Price = phone.Price;
                phoneindb.Manufacturer = phone.Manufacturer;
                phoneindb.RearCamera = phone.RearCamera;
                phoneindb.ScreenSize = phone.ScreenSize;
                phoneindb.Display = phone.Display;
                phoneindb.Colors = phone.Colors;
                phoneindb.ManufacturerId = phone.ManufacturerId;
                phoneindb.CategoryId = phone.CategoryId;
                phoneindb.Image = phone.Image;
            }
            else //if phone does not already exist
                _context.MobilePhones.Add(phone);

                _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //Editing phone only for admin
        [Authorize(Roles = "isAdmin")]
        public ActionResult Edit(int id)
        {
            var mobile = _context.MobilePhones.Single(m => m.Id == id);
            var viewmodal = new MobileManufViewModel
            {
                MobilePhone = mobile,
                Manufacturer = _context.Manufacturer.ToList(),
                Category = _context.Category.ToList()
            };
            //return addmobile model with existing mobile data so you can see and edit  
            return View("AddMobile",viewmodal);
        }


        public ActionResult Details(int id)
        {
            var phone = _context.MobilePhones.Single(m=>m.Id == id);
            phone.Manufacturer = _context.Manufacturer.Single(m => m.Id == phone.ManufacturerId);
            phone.Category = _context.Category.Single(c => c.Id == phone.CategoryId);


            return View(phone);
        }

        [Authorize(Roles = "isAdmin")]
        public ActionResult Delete(int id)
        {
            var mobile = _context.MobilePhones.Single(m => m.Id == id);
            if (mobile == null)
                return HttpNotFound();

            _context.MobilePhones.Remove(mobile);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
