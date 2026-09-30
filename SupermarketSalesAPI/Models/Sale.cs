namespace SupermarketSalesAPI.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public SaleStatus Status { get; set; }
        public decimal Total { get; set; }
        public int BranchId { get; set; }

        public Branch? Branch { get; set; }
        public ICollection<SaleDetail>? SaleDetail { get; set; }
        
    }

    public enum SaleStatus
    {
        Pending,
        Paid,
        Cancelled
    }
}
