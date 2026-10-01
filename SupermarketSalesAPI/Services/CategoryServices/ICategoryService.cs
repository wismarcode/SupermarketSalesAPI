using SupermarketSalesAPI.DTOs.CategoryDTOs;

namespace SupermarketSalesAPI.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto?> GetCategoryByIdAsync(int categoryId);
        Task<CategoryDto?> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<bool> UpdateCategoryAsync(int categoryId, UpdateCategoryDto updateCategoryDto);
        Task<bool> DeleteCategoryAsync(int categoryId);
    }
}
