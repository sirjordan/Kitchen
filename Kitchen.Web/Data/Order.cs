using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen.Web.Data
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public ICollection<Dish> Items { get; set; }

        public DateTime PurchasedAt { get; set; }

        public Order()
        {
            Items = new HashSet<Dish>();
        }
    }
}
