namespace SupermarketSalesAPI.DTOs.SaleDTOs
{
    public class CreateSaleDto
    {
        public int BranchId { get; set; }
        public List<CreateSaleDetailDto> Details { get; set; } = new();
    }
}
