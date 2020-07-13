using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalEstore.cs.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category_code { get; set; }
        public int? ParentId { get; set; }
        public Category Parent { get; set; }
    }
}