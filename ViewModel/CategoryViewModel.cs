using PersonalEstore.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalEstore.cs.ViewModel
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }
        public IEnumerable<Category> ParentsCategories { get; set; }
    }
}