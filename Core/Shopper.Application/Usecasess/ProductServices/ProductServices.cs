using Shopper.Application.Dtos.ProductDtos;
using Shopper.Application.Interfaces;
using Shopper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopper.Application.Usecasess.ProductServices
{
    public class ProductServices : IProductServices
    {
        private readonly IRepository<Product> _repository;

        public ProductServices(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task CreateProductAsync(CreateProductDto dto)
        {
            await _repository.CreateAsync(new Product
            {
                CategoryId = dto.CategoryId,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Price = dto.Price,
                ProductName = dto.ProductName,
                Stock = dto.Stock
            });
        }

        public async Task DeleteProductAsync(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(entity => new ResultProductDto
            {
                ProductId = entity.ProductId,
                CategoryId = entity.CategoryId,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
                Price = entity.Price,
                ProductName = entity.ProductName,
                Stock = entity.Stock
            }).ToList();

        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(int id)
        {
            var values = await _repository.GetByIdAsync(id);
        }

        public Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            throw new NotImplementedException();
        }
    }
}
