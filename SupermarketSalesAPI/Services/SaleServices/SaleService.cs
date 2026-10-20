using SupermarketSalesAPI.DTOs.SaleDTOs;
using SupermarketSalesAPI.Models;
using SupermarketSalesAPI.Repositories.ProductRepositories;
using SupermarketSalesAPI.Repositories.SaleRepositories;
using System.Formats.Asn1;

namespace SupermarketSalesAPI.Services.SaleServices
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;

        public SaleService(ISaleRepository saleRepository, IProductRepository productRepository)
        {
            _saleRepository = saleRepository;
            _productRepository = productRepository;
        }

        public async Task<bool> CancelSaleAsync(int id)
        {
            var sale = await _saleRepository.GetSaleByIdAsync(id);

            if (sale == null)
            {
                return false;
            }

            sale.Status = SaleStatus.Cancelled;

            _saleRepository.CancelSale(sale);
            await _saleRepository.SaveChangesAsync();

            return true;
        }

        public async Task<SaleDto> CreateSaleAsync(CreateSaleDto createSaleDto)
        {
            var sale = new Sale
            {
                Status = SaleStatus.Pending,
                BranchId = createSaleDto.BranchId,
            };

            var detailItems = createSaleDto.Details;

            foreach (var item in detailItems)
            {

                var product = await _productRepository.GetProductByIdAsync(item.ProductId);
                

                var detail = new SaleDetail
                {
                    ProductId = product!.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price,
                    LineTotal = item.Quantity * product.Price
                };

                sale.SaleDetail ??= new List<SaleDetail>();
                sale.SaleDetail.Add(detail);

            }

            sale.Total = sale.SaleDetail!.Sum(d => d.LineTotal);

            await _saleRepository.CreateSaleAsync(sale);
            await _saleRepository.SaveChangesAsync();

            return new SaleDto
            {
                SaleId = sale.SaleId,
                SaleDate = sale.SaleDate,
                Status = sale.Status,
                Total = sale.Total,
                BranchId = sale.BranchId,
            };




        }

        public async Task<bool> DeleteSaleAsync(int id)
        {
            var sale = await _saleRepository.GetSaleByIdAsync(id);

            if (sale == null)
            {
                return false;
            }

            _saleRepository.DeleteSale(sale);
            await _saleRepository.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<SaleDto>> GetAllSalesAsync()
        {
            var sales = await _saleRepository.GetAllSalesAsync();

            var saleDtos = sales.Select(s => new SaleDto
            {
                SaleId = s.SaleId,
                SaleDate = s.SaleDate,
                Status = s.Status,
                Total = s.Total,
                BranchId = s.BranchId
            }).ToList();

            return saleDtos;
        }

        public async Task<SaleDto?> GetSaleByIdAsync(int id)
        {
            var sale = await _saleRepository.GetSaleByIdAsync(id);

            if (sale == null)
                return null;

            return new SaleDto
            {
                SaleId = sale.SaleId,
                SaleDate = sale.SaleDate,
                Status = sale.Status,
                Total = sale.Total,
                BranchId = sale.BranchId,
                BranchName = sale.Branch!.Name,
                Details = sale.SaleDetail!.Select(s => new SaleDetailDto
                {
                    SaleDetailId = s.SaleDetailId,
                    ProductId = s.ProductId,
                    ProductName = s.Product!.Name,
                    Quantity = s.Quantity,
                    UnitPrice = s.UnitPrice,
                    LineTotal = s.LineTotal
                }).ToList()
            };

        }

        public async Task<bool> PaySaleAsync(int id)
        {
            var sale = await _saleRepository.GetSaleByIdAsync(id);

            if (sale == null)
            {
                return false;
            }

            sale.Status = SaleStatus.Paid;

            _saleRepository.PaySale(sale);
            await _saleRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateSaleDetailAsync(int id, int detailId, UpdateSaleDetailDto updateSaleDetailDto)
        {
            var sale = await _saleRepository.GetSaleByIdAsync(id);

            if (sale == null)
            {
                return false;
            }

            var detail = sale.SaleDetail!.FirstOrDefault(d => d.SaleDetailId == detailId);

            if (detail == null)
            {
                return false;
            }

            detail.ProductId = updateSaleDetailDto.ProductId;
            detail.Quantity = updateSaleDetailDto.Quantity;

            var product = await _productRepository.GetProductByIdAsync(updateSaleDetailDto.ProductId);
            detail.UnitPrice = product!.Price;

            detail.LineTotal = detail.Quantity * detail.UnitPrice;

            sale.Total = sale.SaleDetail!.Sum(d => d.LineTotal);

            _saleRepository.UpdateSaleDetail(sale);
            await _saleRepository.SaveChangesAsync();

            return true;
        }
    }
}
