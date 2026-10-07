using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupermarketSalesAPI.DTOs.BranchDTOs;
using SupermarketSalesAPI.Services.BranchServices;

namespace SupermarketSalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBranches()
        {
            var branches = await _branchService.GetAll();
            return Ok(branches);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBranchById(int id)
        {
            var branch = await _branchService.GetById(id);
            if (branch == null)
                return NotFound();
            return Ok(branch);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBranch(CreateBranchDto createBranchDto)
        {
            var branch = await _branchService.CreateBranch(createBranchDto);
            return CreatedAtAction(nameof(GetBranchById), new { id = branch.BranchId }, branch);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBranch(int id, UpdateBranchDto updateBranchDto)
        {
            var result = await _branchService.UpdateBranch(id, updateBranchDto);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBranch(int id)
        {
            var result = await _branchService.DeleteBranch(id);
            if (!result)
                return NotFound();
            return Ok();
        }
    }
}
