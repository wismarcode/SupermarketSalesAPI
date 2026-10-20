using Microsoft.EntityFrameworkCore;
using SupermarketSalesAPI.Data;
using SupermarketSalesAPI.Models;

namespace SupermarketSalesAPI.Repositories.SaleRepositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly AppDbContext _context;

        public SaleRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CancelSale(Sale sale)
        {
            _context.Sales.Update(sale);
        }

        public async Task CreateSaleAsync(Sale sale)
        {
            await _context.Sales.AddAsync(sale);
        }

        public void DeleteSale(Sale sale)
        {
            _context.Sales.Remove(sale);
        }

        public async Task<IEnumerable<Sale>> GetAllSalesAsync()
        {
            return await _context.Sales.AsNoTracking().ToListAsync();
        }

        public async Task<Sale?> GetSaleByIdAsync(int id)
        {
            return await _context.Sales.Include(b => b.Branch).Include(s => s.SaleDetail)!.ThenInclude(p => p.Product).FirstOrDefaultAsync(s => s.SaleId == id);
        }

        public void PaySale(Sale sale)
        {
            _context.Sales.Update(sale);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateSaleDetail(Sale sale)
        {
            _context.Sales.Update(sale);
        }
    }
}
