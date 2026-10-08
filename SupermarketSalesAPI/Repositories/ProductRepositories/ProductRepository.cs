using Microsoft.EntityFrameworkCore;
using SupermarketSalesAPI.Data;
using SupermarketSalesAPI.Models;

namespace SupermarketSalesAPI.Repositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product?> GetProductById(int productId)
        {
            return await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
        }
    }
}
