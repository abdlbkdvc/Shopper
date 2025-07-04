using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopper.Application.Dtos.CustomerDtos;
using Shopper.Application.Usecasess.CustomerServices;

namespace Shopper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;

        public CustomersController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var values = await _customerServices.GetAllCustomerAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var value = await _customerServices.GetByIdCustomerAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto dto)
        {
            await _customerServices.CreateCustomerAsync(dto);
            return Ok("Müşteri başarılı bir şekilde oluşturuldu.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto dto)
        {
            await _customerServices.UpdateCustomerAsync(dto);
            return Ok("Müşteri bilgileri başarılı bir şekilde güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerServices.DeleteCustomerAsync(id);
            return Ok("Müşteri başarılı bir şekilde silindi.");
        }

    }
}
