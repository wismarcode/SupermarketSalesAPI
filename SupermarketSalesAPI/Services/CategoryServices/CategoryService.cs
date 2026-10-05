using SupermarketSalesAPI.DTOs.CategoryDTOs;
using SupermarketSalesAPI.Models;
using SupermarketSalesAPI.Repositories.CategoryRepositories;

namespace SupermarketSalesAPI.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = new Category
            {
                Name = createCategoryDto.Name,
                Description = createCategoryDto.Description
            };


            await _categoryRepository.CreateCategoryAsync(category);
            await _categoryRepository.SaveChangesAsync();

            return new CategoryDto
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description
            };
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (category == null)
                return false;

            _categoryRepository.DeleteCategoryAsync(category);
            await _categoryRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            return categories.Select(c => new CategoryDto
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Description = c.Description
            });
        }
        

        public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (category == null)
                return null;

            return new CategoryDto
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description
            };
        }

        public async Task<bool> UpdateCategoryAsync(int categoryId, UpdateCategoryDto updateCategoryDto)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (category == null)
                return false;

            category.Name = updateCategoryDto.Name;
            category.Description = updateCategoryDto.Description;

            _categoryRepository.UpdateCategoryAsync(category);
            await _categoryRepository.SaveChangesAsync();
            return true;
        }
    }
}
