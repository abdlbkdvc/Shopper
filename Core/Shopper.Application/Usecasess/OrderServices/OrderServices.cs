using Shopper.Application.Dtos.OrderDtos;
using Shopper.Application.Dtos.OrderItemDtos;
using Shopper.Application.Interfaces;
using Shopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopper.Application.Usecasess.OrderServices
{
    public class OrderServices : IOrderServices
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderItem> _orderItemRepository;

        public OrderServices(IRepository<Order> orderRepository, IRepository<OrderItem> orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }

        public async Task CreateOrderAsync(CreateOrderDto dto)
        {
            //public DateTime OrderDate { get; set; }
            //public decimal TotalAmount { get; set; }
            //public string OrderStatus { get; set; }
            //public string BillingAddress { get; set; }
            //public string ShippingAddress { get; set; }
            //public string PaymentMethod { get; set; }
            //public int CustomerId { get; set; }
            //public Customer Customer { get; set; }
            //public ICollection<OrderItem> OrderItems { get; set; }

            var order = new Order
            {
                OrderDate = dto.OrderDate,
                TotalAmount = dto.TotalAmount,
                OrderStatus = dto.OrderStatus,
                ShippingAddress = dto.ShippingAddress,
                PaymentMethod = dto.PaymentMethod,
                CustomerId = dto.CustomerId,
            };
            await _orderRepository.CreateAsync(order);

            foreach (var item in dto.OrderItems)
            {
                await _orderItemRepository.CreateAsync(new OrderItem
                {
                    OrderId = order.OrderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice
                });
            }
        }

        public async Task DeleteOrderAsync(int id)
        {
            var value = await _orderRepository.GetByIdAsync(id);
            await _orderRepository.DeleteAsync(value);
        }

        public async Task<List<ResultOrderDto>> GetAllOrderAsync()
        {
            var values = await _orderRepository.GetAllAsync(); // Include ile birlikte OrderItems gelmeli

            return values.Select(entity => new ResultOrderDto
            {
                OrderId = entity.OrderId,
                OrderDate = entity.OrderDate,
                TotalAmount = entity.TotalAmount,
                OrderStatus = entity.OrderStatus,
                ShippingAddress = entity.ShippingAddress,
                PaymentMethod = entity.PaymentMethod,
                CustomerId = entity.CustomerId,
                OrderItems = entity.OrderItems?
                    .Select(oi => new ResultOrderItemDto
                    {
                        OrderId = oi.OrderId,
                        ProductId = oi.ProductId,
                        Quantity = oi.Quantity,
                        TotalPrice = oi.TotalPrice,
                        OrderItemId = oi.OrderItemId
                    }).ToList() ?? new List<ResultOrderItemDto>()
            }).ToList();
        }


        public async Task<GetByIdOrderDto> GetByIdOrderAsync(int id)
        {
            var value = await _orderRepository.GetByIdAsync(id);
            return new GetByIdOrderDto
            {
                OrderDate = value.OrderDate,
                TotalAmount = value.TotalAmount,
                OrderStatus = value.OrderStatus,
                ShippingAddress = value.ShippingAddress,
                PaymentMethod = value.PaymentMethod,
                CustomerId = value.CustomerId
            };
        }

        public async Task UpdateOrderAsync(UpdateOrderDto dto)
        {
            var value = await _orderRepository.GetByIdAsync(dto.OrderId);
            value.OrderDate = dto.OrderDate;
            value.TotalAmount = dto.TotalAmount;
            value.OrderStatus = dto.OrderStatus;
            value.ShippingAddress = dto.ShippingAddress;
            value.CustomerId = dto.CustomerId;
            value.PaymentMethod = dto.PaymentMethod;
            await _orderRepository.UpdateAsync(value);

        }
    }
}
