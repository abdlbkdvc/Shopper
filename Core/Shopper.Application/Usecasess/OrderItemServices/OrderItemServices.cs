using Shopper.Application.Dtos.OrderItemDtos;
using Shopper.Application.Interfaces;
using Shopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopper.Application.Usecasess.OrderItemServices
{
    public class OrderItemServices : IOrderItemServices
    {
        private readonly IRepository<OrderItem> _repository;

        public OrderItemServices(IRepository<OrderItem> repository)
        {
            _repository = repository;
        }

        public async Task CreateOrderItemAsync(CreateOrderItemDto dto)
        {
            await _repository.CreateAsync(new OrderItem
            {
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                TotalPrice = dto.TotalPrice
            });
        }

        public async Task DeleteOrderItemAsync(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<List<ResultOrderItemDto>> GetAllOrderItemAsync()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(entity => new ResultOrderItemDto
            {
                OrderId = entity.OrderId,
                OrderItemId = entity.OrderItemId,
                ProductId = entity.ProductId,
                Quantity = entity.Quantity,
                TotalPrice = entity.TotalPrice
            }).ToList();
        }

        public async Task<GetByIdOrderItemDto> GetByIdOrderItemAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return new GetByIdOrderItemDto
            {
                OrderId = entity.OrderId,
                OrderItemId = entity.OrderItemId,
                ProductId = entity.ProductId,
                Quantity = entity.Quantity,
                TotalPrice = entity.TotalPrice
            };
        }

        public async Task UpdateOrderItemAsync(UpdateOrderItemDto dto)
        {
            await _repository.UpdateAsync(new OrderItem
            {
                OrderId = dto.OrderId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                TotalPrice = dto.TotalPrice
            });
        }
    }
}
