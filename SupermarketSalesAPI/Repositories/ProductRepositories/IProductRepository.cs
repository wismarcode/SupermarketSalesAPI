using SupermarketSalesAPI.Models;

namespace SupermarketSalesAPI.Repositories.ProductRepositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product?> GetProductById(int productId);
        Task CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        Task SaveChanges();
    }
}
