using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalEstore.cs.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public int Stock { get; set; }
        public string Image { get; set; }

    }
}