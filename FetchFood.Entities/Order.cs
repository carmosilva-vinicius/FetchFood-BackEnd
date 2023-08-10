﻿using FetchFood.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchFood.Entities
{
    internal class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
    }
}
