﻿using Shopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopper.Application.Dtos.OrderItemDtos
{
    public class UpdateOrderItemDto
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        //public Order Order { get; set; }
        public int ProductId { get; set; }
        //public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
