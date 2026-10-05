using Microsoft.EntityFrameworkCore;
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

        public async Task CreateCategoryAsync(Category category)
        {
           await _context.Categories.AddAsync(category);
        }

        public void DeleteCategoryAsync(Category category)
        {
            _context.Categories.Remove(category);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }
        

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
