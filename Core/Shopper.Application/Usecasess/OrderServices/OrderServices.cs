using Shopper.Application.Dtos.OrderDtos;
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
        private readonly IRepository<Order> _repository;

        public OrderServices(IRepository<Order> repository)
        {
            _repository = repository;
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

            await _repository.CreateAsync(new Order
            {
                OrderDate = dto.OrderDate,
                TotalAmount = dto.TotalAmount,
                OrderStatus = dto.OrderStatus,
                BillingAddress = dto.BillingAddress,
                ShippingAddress = dto.ShippingAddress,
                PaymentMethod = dto.PaymentMethod,
                CustomerId = dto.CustomerId
            });
        }

        public async Task DeleteOrderAsync(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<List<ResultOrderDto>> GetAllOrderAsync()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(entity => new ResultOrderDto
            {
                OrderDate = entity.OrderDate,
                TotalAmount = entity.TotalAmount,
                OrderStatus = entity.OrderStatus,
                BillingAddress = entity.BillingAddress,
                ShippingAddress = entity.ShippingAddress,
                PaymentMethod = entity.PaymentMethod,
                CustomerId = entity.CustomerId
            }).ToList();

        }

        public async Task<GetByIdOrderDto> GetByIdOrderAsync(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return new GetByIdOrderDto
            {
                OrderDate = value.OrderDate,
                TotalAmount = value.TotalAmount,
                OrderStatus = value.OrderStatus,
                BillingAddress = value.BillingAddress,
                ShippingAddress = value.ShippingAddress,
                PaymentMethod = value.PaymentMethod,
                CustomerId = value.CustomerId
            };
        }

        public async Task UpdateOrderAsync(UpdateOrderDto dto)
        {
            var value = await _repository.GetByIdAsync(dto.OrderId);
            value.OrderDate = dto.OrderDate;
            value.TotalAmount = dto.TotalAmount;
            value.OrderStatus = dto.OrderStatus;
            value.ShippingAddress = dto.ShippingAddress;
            value.BillingAddress = dto.BillingAddress;
            value.CustomerId = dto.CustomerId;
            value.PaymentMethod = dto.PaymentMethod;
            await _repository.UpdateAsync(value);

        }
    }
}
