using SupermarketSalesAPI.DTOs.CategoryDTOs;

namespace SupermarketSalesAPI.DTOs.ProductDTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
    }
}
