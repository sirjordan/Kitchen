using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kitchen.Web.Models
{
    public class DishViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageBase64 { get; set; }
        public double Price { get; set; }
    }
}