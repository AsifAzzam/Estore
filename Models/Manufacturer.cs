using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalEstore.cs.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int ContactNo { get; set; }
        [Required]
        public string Email { get; set; }

        internal IEnumerable<object> where(object p)
        {
            throw new NotImplementedException();
        }
    }
}