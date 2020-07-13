using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace PersonalEstore.cs.Models
{

    public class MobilePhones:Item
    {

        [Required]
        public string ScreenSize { get; set; }
        [Required]
        public byte FrontCamera { get; set; }
        [Required]
        public byte RearCamera { get; set; }
        [Required]
        public string Display { get; set; }
        [Required]
        public string Colors { get; set; }        

    }

}