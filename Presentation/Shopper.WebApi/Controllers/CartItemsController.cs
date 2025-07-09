using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopper.Application.Dtos.CartItemDtos;
using Shopper.Application.Usecasess.CartItemServices;

namespace Shopper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemServices _services;

        public CartItemsController(ICartItemServices services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCartItem()
        {
            var values = await _services.GetAllCartItemAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCartItem(int id)
        {
            var value = await _services.GetByIdCartItemAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCartItem(CreateCartItemDto dto)
        {
            await _services.CreateCartItemAsync(dto);
            return Ok("Cart Item başarılı bir şekilde oluşturuldu.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCartItem(UpdateCartItemDto dto)
        {
            await _services.UpdateCartItemAsync(dto);
            return Ok("Cart Item başarılı bir şekilde güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            await _services.DeleteCartItemAsync(id);
            return Ok("Cart Item başarılı bir şekilde silindi.");
        }

    }
}
