using SupermarketSalesAPI.Models;

namespace SupermarketSalesAPI.Repositories.BranchRepositories
{
    public interface IBranchRepository
    {
        Task<IEnumerable<Branch>> GetAllBranches();
        Task<Branch> GetBranchById(int id);
        Task CreateBranch(Branch branch);
        Task SaveChanges();
        void UpdateBranch(Branch branch);
        void DeleteBranch(Branch branch);
    }
}
