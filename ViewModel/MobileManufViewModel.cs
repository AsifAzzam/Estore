using PersonalEstore.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalEstore.cs.ViewModel
{
    public class MobileManufViewModel
    {
        public MobilePhones MobilePhone { get; set; }
        public IEnumerable<Manufacturer>  Manufacturer { get; set; }
        public IEnumerable<Category> Category { get; set; }

    }
}