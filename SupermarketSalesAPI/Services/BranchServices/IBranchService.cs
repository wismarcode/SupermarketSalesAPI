using SupermarketSalesAPI.DTOs.BranchDTOs;

namespace SupermarketSalesAPI.Services.BranchServices
{
    public interface IBranchService
    {
        Task<IEnumerable<BranchDto>> GetAll();
        Task<BranchDto> GetById(int id);
        Task<BranchDto> CreateBranch(CreateBranchDto CreateBranchDto);
        Task UpdateBranch(int id, UpdateBranchDto updateBranchDto);
        Task DeleteBranch(int id);
    }
}
