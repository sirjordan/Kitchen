namespace Kitchen.Web.Models
{
    public class DishViewModel
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public string Allergens { get; set; }

        public string ImageUrl { get; set; }

        public int Weight { get; set; }
    }
}
