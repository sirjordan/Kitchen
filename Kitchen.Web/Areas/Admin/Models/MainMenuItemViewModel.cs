using Kitchen.Web.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Kitchen.Web.Areas.Admin.Models
{
    public class MainMenuItemViewModel
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public string Allergens { get; set; }

        public string ImageUrl { get; set; }

        public int Weight { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
