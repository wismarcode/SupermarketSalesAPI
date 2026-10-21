using SupermarketSalesAPI.DTOs.ProductDTOs;

namespace SupermarketSalesAPI.Services.ProductServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(int productId);
        Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(int productId, UpdateProductDto updateProductDto);
        Task DeleteProductAsync(int productId);
    }
}
