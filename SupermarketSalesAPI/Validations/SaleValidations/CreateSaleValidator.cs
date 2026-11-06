using FluentValidation;
using SupermarketSalesAPI.DTOs.SaleDTOs;

namespace SupermarketSalesAPI.Validations.SaleValidations
{
    public class CreateSaleValidator : AbstractValidator<CreateSaleDto>
    {
        public CreateSaleValidator()
        {
            RuleFor(x => x.BranchId)
                .NotNull().WithMessage("BranchId is required.")
                .GreaterThan(0).WithMessage("BranchId must be greater than 0.");
            RuleForEach(x => x.Details).SetValidator(new CreateSaleDetailValidator());
        }
    }
}
