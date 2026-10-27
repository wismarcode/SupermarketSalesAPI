using FluentValidation;
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
        private readonly IValidator<CreateBranchDto> _createBranchValidator;
        private readonly IValidator<UpdateBranchDto> _updateBranchValidator;

        public BranchController(IBranchService branchService, IValidator<CreateBranchDto> createBranchValidator, IValidator<UpdateBranchDto> updateBranchValidator)
        {
            _branchService = branchService;
            _createBranchValidator = createBranchValidator;
            _updateBranchValidator = updateBranchValidator;
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
            var validationResult = await _createBranchValidator.ValidateAsync(createBranchDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var branch = await _branchService.CreateBranch(createBranchDto);
            return CreatedAtAction(nameof(GetBranchById), new { id = branch.BranchId }, branch);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBranch(int id, UpdateBranchDto updateBranchDto)
        {
            var validationResult = await _updateBranchValidator.ValidateAsync(updateBranchDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await _branchService.UpdateBranch(id, updateBranchDto);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBranch(int id)
        {
            try
            {
                await _branchService.DeleteBranch(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
