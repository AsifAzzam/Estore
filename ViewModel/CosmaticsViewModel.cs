using PersonalEstore.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalEstore.cs.ViewModel
{
    public class CosmaticsViewModel
    {
        public Cosmatics Cosmatics { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<Manufacturer> Manufacturer { get; set; }
    }
}