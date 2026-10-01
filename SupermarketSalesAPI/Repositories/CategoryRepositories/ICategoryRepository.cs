using SupermarketSalesAPI.Models;

namespace SupermarketSalesAPI.Repositories.CategoryRepositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        void DeleteCategoryAsync(Category category);
        void UpdateCategoryAsync(Category category);
        Task CreateCategoryAsync(Category category);
        Task SaveChangesAsync();
    }
}
