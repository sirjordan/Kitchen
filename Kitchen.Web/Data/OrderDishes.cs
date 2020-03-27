namespace Kitchen.Web.Data
{
    public class OrderDishes
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
