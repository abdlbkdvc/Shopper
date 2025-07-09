using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopper.Application.Dtos.ProductDtos;
using Shopper.Application.Usecasess.ProductServices;

namespace Shopper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _services;

        public ProductsController(IProductServices services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var values = await _services.GetAllProductAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProduct(int id)
        {
            var value = await _services.GetByIdProductAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            await _services.CreateProductAsync(dto);
            return Ok("Ürününüz başarılı bir şekilde oluşturuldu.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
        {
            await _services.UpdateProductAsync(dto);
            return Ok("Ürününüz başarılı bir şekilde güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _services.DeleteProductAsync(id);
            return Ok("Ürününüz başarılı bir şekilde silindi.");
        }

    }
}
