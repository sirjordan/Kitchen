using System.Collections.Generic;
using System.Linq;

namespace Kitchen.Web.Models
{
    public class CartViewModel
    {
        public List<DishViewModel> Items { get; set; }

        public double TotalPrice
        {
            get { return Items.Sum(i => i.Price); } 
        }

        public CartViewModel()
        {
            Items = new List<DishViewModel>();
        }
    }
}
