using Shopper.Application.Dtos.CartDtos;
using Shopper.Application.Dtos.CartItemDtos;
using Shopper.Application.Interfaces;
using Shopper.Domain.Entities;

namespace Shopper.Application.Usecasess.CartServices
{
    public class CartServices : ICartServices
    {
        private readonly IRepository<Cart> _repository;
        private readonly IRepository<CartItem> _itemRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Product> _productRepository;

        public CartServices(IRepository<Cart> repository, IRepository<CartItem> itemRepository, IRepository<Customer> customerRepository, IRepository<Product> productRepository)
        {
            _repository = repository;
            _itemRepository = itemRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public async Task CreateCartAsync(CreateCartDto dto)
        {
            var cart = new Cart
            {
                //TotalAmount = dto.TotalAmount,
                CreatedDate = dto.CreatedDate,
                CustomerId = dto.CustomerId,
            };
            await _repository.CreateAsync(cart);
            var sum = 0;
            foreach (var item in dto.CartItems)
            {
                var cartitem = new CartItem
                {
                    CartId = cart.CartId,
                    ProductId = item.ProductId,
                    TotalPrice = item.TotalPrice,
                    Quantity = item.Quantity
                };
                sum += (item.Quantity * item.TotalPrice);
                await _itemRepository.CreateAsync(cartitem);

            }
            cart.TotalAmount = sum;
            await _repository.UpdateAsync(cart);
        }

        public async Task DeleteCartAsync(int id)
        {
            var cart = await _repository.GetByIdAsync(id);
            var cartItems = await _itemRepository.GetAllAsync();
            foreach (var item in cartItems)
            {
                if (item.CartId == id)
                {
                    var cartitem = await _itemRepository.GetByIdAsync(item.CartItemId);
                    await _itemRepository.DeleteAsync(cartitem);
                }
            }
            await _repository.DeleteAsync(cart);
        }

        public async Task<List<ResultCartDto>> GetAllCartAsync()
        {
            var carts = await _repository.GetAllAsync();
            var cartItems = await _itemRepository.GetAllAsync();
            var product = await _productRepository.GetAllAsync();
            var result = new List<ResultCartDto>();
            foreach (var item in carts)
            {
                var customerdto = await _customerRepository.GetByFilterAsync(cus => cus.CustomerId == item.CustomerId);
                var cartDto = new ResultCartDto
                {
                    CartId = item.CartId,
                    CreatedDate = item.CreatedDate,
                    CustomerId = item.CustomerId,
                    Customer = customerdto,
                    TotalAmount = item.TotalAmount,
                    CartItems = new List<ResultCartItemDto>()
                };
                foreach (var item1 in item.CartItems)
                {
                    var productdto = await _productRepository.GetByFilterAsync(prd => prd.ProductId == item1.ProductId);
                    var cartItemdto = new ResultCartItemDto
                    {
                        CartId = item1.CartId,
                        CartItemId = item1.CartItemId,
                        ProductId = item1.ProductId,
                        Product = productdto,
                        Quantity = item1.Quantity,
                        TotalPrice = item1.TotalPrice
                    };
                    cartDto.CartItems.Add(cartItemdto);
                }
                result.Add(cartDto);
            }
            return result;

        }

        public async Task<GetByIdCartDto> GetByIdCartAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            var customer = await _customerRepository.GetByIdAsync(id);
            var result = new GetByIdCartDto
            {
                CartId = entity.CartId,
                CreatedDate = entity.CreatedDate,
                CustomerId = entity.CustomerId,
                TotalAmount = entity.TotalAmount
            };
            return result;
        }

        public async Task UpdateCartAsync(UpdateCartDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.CartId);
            entity.CreatedDate = dto.CreatedDate;
            entity.CustomerId = dto.CustomerId;
            entity.TotalAmount = dto.TotalAmount;
            await _repository.UpdateAsync(entity);
        }
    }
}
