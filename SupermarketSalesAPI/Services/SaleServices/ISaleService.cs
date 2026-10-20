using SupermarketSalesAPI.DTOs.SaleDTOs;

namespace SupermarketSalesAPI.Services.SaleServices
{
    public interface ISaleService
    {
        Task<IEnumerable<SaleDto>> GetAllSalesAsync();
        Task<SaleDto?> GetSaleByIdAsync(int id);
        Task<SaleDto> CreateSaleAsync(CreateSaleDto createSaleDto);
        Task PaySaleAsync(int id);
        Task CancelSaleAsync(int id);
        Task UpdateSaleDetailAsync(int saleId, int detailId, UpdateSaleDetailDto updateSaleDetailDto);
        Task DeleteSaleAsync(int id);
    }
}
