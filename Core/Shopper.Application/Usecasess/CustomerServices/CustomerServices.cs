using Shopper.Application.Dtos.CustomerDtos;
using Shopper.Application.Interfaces;
using Shopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopper.Application.Usecasess.CustomerServices
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IRepository<Customer> _repository;

        public CustomerServices(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            await _repository.CreateAsync(new Customer
            {
                FirstName = createCustomerDto.FirstName,
                LastName = createCustomerDto.LastName,
                Email = createCustomerDto.Email
            });
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<List<ResultCustomerDto>> GetAllCustomerAsync()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(entity => new ResultCustomerDto
            {
                CustomerId = entity.CustomerId,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                //Orders = entity.Orders
            }).ToList();
        }

        public async Task<GetByIdCustomerDto> GetByIdCustomerAsync(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return new GetByIdCustomerDto
            {
                CustomerId = value.CustomerId,
                Email = value.Email,
                FirstName = value.FirstName,
                LastName = value.LastName,
                //Orders = value.Orders
            };
        }

        public async Task UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto)
        {
            var value = await _repository.GetByIdAsync(updateCustomerDto.CustomerId);
            value.FirstName = updateCustomerDto.FirstName;
            value.LastName = updateCustomerDto.LastName;
            value.Email = updateCustomerDto.Email;
            //value.Orders = updateCustomerDto.Orders;
            await _repository.UpdateAsync(value);
        }
    }
}
