using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopper.Application.Dtos.OrderItemDtos;
using Shopper.Application.Usecasess.OrderItemServices;

namespace Shopper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemServices _services;

        public OrderItemsController(IOrderItemServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderItem()
        {
            var values = await _services.GetAllOrderItemAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdOrderItem(int id)
        {
            var value = await _services.GetByIdOrderItemAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderItem(CreateOrderItemDto dto)
        {
            await _services.CreateOrderItemAsync(dto);
            return Ok("OrderItem başarılı bir şekilde oluşturuldu.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderItem(UpdateOrderItemDto dto)
        {
            await _services.UpdateOrderItemAsync(dto);
            return Ok("OrderItem başarılı bir şekilde güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            await _services.DeleteOrderItemAsync(id);
            return Ok("OrderItem başarılı bir şekilde silindi.");
        }
    }
}
