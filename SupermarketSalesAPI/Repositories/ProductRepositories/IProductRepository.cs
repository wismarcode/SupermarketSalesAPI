using SupermarketSalesAPI.Models;

namespace SupermarketSalesAPI.Repositories.ProductRepositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int productId);
        Task CreateProductAsync(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        Task SaveChangesAsync();
    }
}
