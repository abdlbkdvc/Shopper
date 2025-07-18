﻿using Shopper.Application.Dtos.CartItemDtos;
using Shopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopper.Application.Dtos.CartDtos
{
    public class GetByIdCartDto
    {
        public int CartId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<ResultCartItemDto>? CartItems { get; set; }
    }
}
