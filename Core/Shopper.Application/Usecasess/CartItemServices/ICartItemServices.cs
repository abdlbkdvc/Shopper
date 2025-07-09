using Shopper.Application.Dtos.CartItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopper.Application.Usecasess.CartItemServices
{
    public interface ICartItemServices
    {
        Task<List<ResultCartItemDto>> GetAllCartItemAsync();
        Task<GetByIdCartItemDto> GetByIdCartItemAsync(int id);
        Task CreateCartItemAsync(CreateCartItemDto createCartItemDto);
        Task UpdateCartItemAsync(UpdateCartItemDto updateCartItemDto);
        Task DeleteCartItemAsync(int id);
        Task<List<ResultCartItemDto>> GetByCartIdCartItemAsync(int cartId);
    }
}
