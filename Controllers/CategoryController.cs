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
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;
        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }



        // GET: MobilePhones
        public ActionResult Index()
        {
            var category = _context.Category.Include(p=>p.Parent).ToList();

            return View("Index", category);
        }

        //rendering add form for category
        public ActionResult AddCategory()
        {
            var viewmodel = new CategoryViewModel()
            {
                Category = new Category(),
                ParentsCategories = _context.Category.Include(p => p.Parent).ToList()
            };
            

            return View(viewmodel);
        }

        //saving category to database
        [HttpPost]
        public ActionResult SaveCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new CategoryViewModel
                {
                    Category = category,
                    ParentsCategories = _context.Category.Include(p => p.Parent).ToList()
                };
                return View("AddCategory", viewmodel);

            }
            //if category already exist than update
            if (category.Id != 0)
            {
                var categoryindb = _context.Category.Single(m => m.Id == category.Id);
                if (categoryindb == null)
                    RedirectToAction("AddCategory");
                categoryindb.Name = category.Name;
                categoryindb.Category_code = category.Category_code;
                categoryindb.ParentId = category.ParentId;
            }
            else //adding to database
                _context.Category.Add(category);

            _context.SaveChanges();

            return RedirectToAction("Index", "Category");
        }

        public ActionResult Edit(int id)
        {
            CategoryViewModel viewModel = new CategoryViewModel
            {
                Category = _context.Category.Single(m => m.Id == id),
                ParentsCategories = _context.Category.ToList()
            };
            
            return View("AddCategory", viewModel);
        }

        public ActionResult Details(int id)
        {
            var category = _context.Category.Single(m => m.Id == id);
            if (category == null)
                return HttpNotFound();


            return View(category);
        }

        public ActionResult Delete(int id)
        {
            var category = _context.Category.Single(m => m.Id == id);
            if (category == null)
                return HttpNotFound();

            _context.Category.Remove(category);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}