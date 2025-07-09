using Shopper.Application.Dtos.CartItemDtos;
using Shopper.Application.Interfaces;
using Shopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopper.Application.Usecasess.CartItemServices
{
    public class CartItemServices : ICartItemServices
    {
        private readonly IRepository<CartItem> _repository;

        public CartItemServices(IRepository<CartItem> repository)
        {
            _repository = repository;
        }

        public async Task CreateCartItemAsync(CreateCartItemDto dto)
        {
            var cartItem = new CartItem
            {
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                TotalPrice = dto.TotalPrice,
            };
            await _repository.CreateAsync(cartItem);
        }

        public async Task DeleteCartItemAsync(int id)
        {
            var cartItem = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(cartItem);
        }

        public async Task<List<ResultCartItemDto>> GetAllCartItemAsync()
        {
            var cartItems = await _repository.GetAllAsync();
            return cartItems.Select(entity => new ResultCartItemDto
            {
                CartId = entity.CartId,
                ProductId = entity.ProductId,
                CartItemId = entity.CartItemId,
                Quantity = entity.Quantity,
                TotalPrice = entity.TotalPrice
            }).ToList();
        }

        public Task<List<ResultCartItemDto>> GetByCartIdCartItemAsync(int cartId)
        {
            throw new NotImplementedException();
        }

        public async Task<GetByIdCartItemDto> GetByIdCartItemAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return new GetByIdCartItemDto
            {
                CartId = entity.CartId,
                CartItemId = entity.CartItemId,
                ProductId = entity.ProductId,
                Quantity = entity.Quantity,
                TotalPrice = entity.TotalPrice
            };
        }

        public async Task UpdateCartItemAsync(UpdateCartItemDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.CartItemId);
            entity.Quantity = dto.Quantity;
            entity.TotalPrice = dto.TotalPrice;
            entity.ProductId = dto.ProductId;
            entity.CartId = dto.CartId;
            await _repository.UpdateAsync(entity);
        }
    }
}
