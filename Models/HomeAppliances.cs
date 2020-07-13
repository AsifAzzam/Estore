using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalEstore.cs.Models
{
    public class HomeAppliances:Item
    {
        public byte Size { get; set; }
        public string Colors { get; set; }
        public string Display { get; set; }
    }
}