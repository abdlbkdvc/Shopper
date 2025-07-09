﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopper.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        //public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public string PaymentMethod { get; set; }
        public int CustomerId { get; set; }
        //public Customer Customer { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
