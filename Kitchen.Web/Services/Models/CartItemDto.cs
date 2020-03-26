using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen.Web.Services.Models
{
    public class CartItemDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}
