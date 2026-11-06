using FluentValidation;
using SupermarketSalesAPI.DTOs.SaleDTOs;

namespace SupermarketSalesAPI.Validations.SaleValidations
{
    public class CreateSaleDetailValidator : AbstractValidator<CreateSaleDetailDto>
    {
        public CreateSaleDetailValidator()
        {
            RuleFor(x => x.ProductId)
                .NotNull().WithMessage("ProductId is required.")
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
            RuleFor(x => x.Quantity)
                .NotNull().WithMessage("Quantity is required.")
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
    }
}
