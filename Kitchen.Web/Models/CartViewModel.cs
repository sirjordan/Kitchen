using System.Collections.Generic;

namespace Kitchen.Web.Models
{
    public class CartViewModel
    {
        public List<int> ItemIds { get; set; }

        public CartViewModel()
        {
            ItemIds = new List<int>();
        }
    }
}
