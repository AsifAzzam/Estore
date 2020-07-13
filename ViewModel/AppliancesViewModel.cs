using PersonalEstore.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalEstore.cs.ViewModel
{
    public class AppliancesViewModel
    {
        public HomeAppliances Appliances { get; set; }
        public IEnumerable<Manufacturer> Manufacturers { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}