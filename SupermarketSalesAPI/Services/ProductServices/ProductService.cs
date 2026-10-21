using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupermarketSalesAPI.DTOs.CategoryDTOs;
using SupermarketSalesAPI.DTOs.ProductDTOs;
using SupermarketSalesAPI.Models;
using SupermarketSalesAPI.Repositories.ProductRepositories;

namespace SupermarketSalesAPI.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }



        public async Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = new Product
            {
                Name = createProductDto.Name,
                Price = createProductDto.Price,
                Stock = createProductDto.Stock,
                CategoryId = createProductDto.CategoryId
            };

            await _productRepository.CreateProductAsync(product);
            await _productRepository.SaveChangesAsync();

            return new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId
            };
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found.");

            _productRepository.DeleteProduct(product);
            await _productRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return products.Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                CategoryId = p.CategoryId
            });
        }
        

        public async Task<ProductDto?> GetProductByIdAsync(int productId)
        {
            var product =  await _productRepository.GetProductByIdAsync(productId);

            if (product == null)
                return null;

            return new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
                Category = product.Category == null ? null : new CategoryDto
                {
                    CategoryId = product.Category.CategoryId,
                    Name = product.Category.Name,
                    Description = product.Category.Description
                }
            };


        }

        public async Task UpdateProductAsync(int productId, UpdateProductDto updateProductDto)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found.");

            product.Name = updateProductDto.Name;
            product.Price = updateProductDto.Price;
            product.Stock = updateProductDto.Stock;
            product.CategoryId = updateProductDto.CategoryId;


            _productRepository.UpdateProduct(product);
            await _productRepository.SaveChangesAsync();

        }
    }
}
