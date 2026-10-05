namespace SupermarketSalesAPI.DTOs.BranchDTOs
{
    public class BranchDto
    {
        public int BranchId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
