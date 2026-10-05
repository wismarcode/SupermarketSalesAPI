using SupermarketSalesAPI.DTOs.BranchDTOs;
using SupermarketSalesAPI.Models;
using SupermarketSalesAPI.Repositories.BranchRepositories;

namespace SupermarketSalesAPI.Services.BranchServices
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<BranchDto> CreateBranch(CreateBranchDto createBranchDto)
        {
            var branch = new Branch
            {
                Name = createBranchDto.Name,
                Address = createBranchDto.Address
            };

            await _branchRepository.CreateBranch(branch);
            await _branchRepository.SaveChanges();

            return new BranchDto
            {
                BranchId = branch.BranchId,
                Name = branch.Name,
                Address = branch.Address
            };
        }

        public async Task<bool> DeleteBranch(int id)
        {
            var branch = await _branchRepository.GetBranchById(id);

            if (branch == null)
                return false;

            _branchRepository.DeleteBranch(branch);
            await _branchRepository.SaveChanges();

            return true;
        }

        public async Task<IEnumerable<BranchDto>> GetAll()
        {
            var branches = await _branchRepository.GetAllBranches();
            return branches.Select(b => new BranchDto
            {
                BranchId = b.BranchId,
                Name = b.Name,
                Address = b.Address
            });
        }

        public async Task<BranchDto> GetById(int id)
        {
            var branch = await _branchRepository.GetBranchById(id);
            if (branch == null)
                return null;

            return new BranchDto
            {
                BranchId = branch.BranchId,
                Name = branch.Name,
                Address = branch.Address
            };
        }

        public async Task<bool> UpdateBranch(int id, UpdateBranchDto updateBranchDto)
        {
            var branch = await _branchRepository.GetBranchById(id);
            if (branch == null)
                return false;

            branch.Name = updateBranchDto.Name;
            branch.Address = updateBranchDto.Address;

            _branchRepository.UpdateBranch(branch);
            await _branchRepository.SaveChanges();

            return true;
        }
    }
}
