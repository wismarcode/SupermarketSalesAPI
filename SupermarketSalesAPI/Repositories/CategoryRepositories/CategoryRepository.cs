using SupermarketSalesAPI.Data;
using SupermarketSalesAPI.Models;

namespace SupermarketSalesAPI.Repositories.CategoryRepositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Category> CreateCategoryAsync(Category category)
        {
            _context.Categories.AddAsync(category);
        }

        public void DeleteCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
