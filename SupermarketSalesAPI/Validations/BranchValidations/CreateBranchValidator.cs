using FluentValidation;
using SupermarketSalesAPI.DTOs.BranchDTOs;
namespace SupermarketSalesAPI.Validations.BranchValidations
{
    public class CreateBranchValidator : AbstractValidator<CreateBranchDto>
    {
        public CreateBranchValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("Branch name is required.")
                .Length(3, 50).WithMessage("Branch name cannot exceed 50 characters.");
            RuleFor(b => b.Address)
                .NotEmpty().WithMessage("Branch address is required.")
                .MaximumLength(100).WithMessage("Branch address cannot exceed 100 characters.");
        }
    
    }
}
