﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kitchen.Web.Data
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual ICollection<OrderDishes> Dishes { get; set; }

        public DateTime PurchasedAt { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public Order()
        {
            Dishes = new HashSet<OrderDishes>();
        }
    }
}
