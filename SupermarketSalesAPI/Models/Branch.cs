namespace SupermarketSalesAPI.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public ICollection<Sale>? Sale { get; set; }
    }
}
