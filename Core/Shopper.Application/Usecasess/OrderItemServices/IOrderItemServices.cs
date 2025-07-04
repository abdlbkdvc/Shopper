using Shopper.Application.Dtos.OrderItemDtos;

namespace Shopper.Application.Usecasess.OrderItemServices
{
    public interface IOrderItemServices
    {
        Task<List<ResultOrderItemDto>> GetAllOrderItemAsync();
        Task<GetByIdOrderItemDto> GetByIdOrderItemAsync(int id);
        Task CreateOrderItemAsync(CreateOrderItemDto createOrderItemDto);
        Task UpdateOrderItemAsync(UpdateOrderItemDto updateOrderItemDto);
        Task DeleteOrderItemAsync(int id);
    }
}
