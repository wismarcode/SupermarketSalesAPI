using SupermarketSalesAPI.Models;

namespace SupermarketSalesAPI.DTOs.SaleDTOs
{
    public class SaleDto
    {
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public SaleStatus Status { get; set; }
        public decimal Total { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;

        public List<SaleDetailDto>? Details { get; set; }
    }
}
