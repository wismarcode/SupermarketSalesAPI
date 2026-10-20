using SupermarketSalesAPI.DTOs.SaleDTOs;

namespace SupermarketSalesAPI.Services.SaleServices
{
    public interface ISaleService
    {
        Task<IEnumerable<SaleDto>> GetAllSalesAsync();
        Task<SaleDto?> GetSaleByIdAsync(int id);
        Task<SaleDto> CreateSaleAsync(CreateSaleDto createSaleDto);
        Task<bool> PaySaleAsync(int id);
        Task<bool> CancelSaleAsync(int id);
        Task<bool> UpdateSaleDetailAsync(int saleId, int detailId, UpdateSaleDetailDto updateSaleDetailDto);
        Task<bool> DeleteSaleAsync(int id);
    }
}
