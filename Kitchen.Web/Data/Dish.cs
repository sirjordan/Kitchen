﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kitchen.Web.Data
{
    public class Dish
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string Allergens { get; set; }

        public string ImageUrl { get; set; }

        public int Weight { get; set; }

        public virtual ICollection<OrderDishes> Orders { get; set; }

        public Dish()
        {
            Orders = new HashSet<OrderDishes>();
        }
    }
}