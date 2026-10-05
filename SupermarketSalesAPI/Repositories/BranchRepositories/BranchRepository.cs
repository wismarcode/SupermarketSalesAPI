using Microsoft.EntityFrameworkCore;
using SupermarketSalesAPI.Data;
using SupermarketSalesAPI.Models;

namespace SupermarketSalesAPI.Repositories.BranchRepositories
{
    public class BranchRepository : IBranchRepository
    {

        private readonly AppDbContext _context;

        public BranchRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateBranch(Branch branch)
        {
            await _context.Branches.AddAsync(branch);
        }

        public void DeleteBranch(Branch branch)
        {
            _context.Branches.Remove(branch);
        }

        public async Task<IEnumerable<Branch>> GetAllBranches()
        {
            return await _context.Branches.AsNoTracking().ToListAsync();
        }

        public async Task<Branch> GetBranchById(int id)
        {
            return await _context.Branches.FirstOrDefaultAsync(b => b.BranchId == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateBranch(Branch branch)
        {
            _context.Branches.Update(branch);
        }
    }
}
