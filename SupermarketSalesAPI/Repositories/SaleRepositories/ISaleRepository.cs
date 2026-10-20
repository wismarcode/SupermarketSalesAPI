using SupermarketSalesAPI.Models;

namespace SupermarketSalesAPI.Repositories.SaleRepositories
{
    public interface ISaleRepository
    {
        Task CreateSaleAsync(Sale sale);
        Task<IEnumerable<Sale>> GetAllSalesAsync();
        Task<Sale?> GetSaleByIdAsync(int id);
        Task SaveChangesAsync();
        void UpdateSaleDetail(Sale sale);
        void PaySale(Sale sale);
        void CancelSale(Sale sale);
        void DeleteSale(Sale sale);
    }
}
