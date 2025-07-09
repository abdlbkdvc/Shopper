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
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
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
            var entity = await _repository.GetByIdAsync(id);
            return new GetByIdProductDto
            {
                CategoryId = entity.CategoryId,
                Description = entity.Description,
                ImageUrl = entity.ImageUrl,
                Price = entity.Price,
                ProductId = entity.ProductId,
                ProductName = entity.ProductName,
                Stock = entity.Stock
            };
        }

        public async Task UpdateProductAsync(UpdateProductDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.ProductId);
            entity.ProductName = dto.ProductName;
            entity.Stock = dto.Stock;
            entity.ImageUrl = dto.ImageUrl;
            entity.Price = dto.Price;
            entity.Description = dto.Description;
            entity.CategoryId = dto.CategoryId;
            await _repository.UpdateAsync(entity);
        }
    }
}
