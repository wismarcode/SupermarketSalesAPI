using FluentValidation;
using SupermarketSalesAPI.DTOs.ProductDTOs;

namespace SupermarketSalesAPI.Validations.ProductValidations
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(3, 50);
            RuleFor(x => x.Price).NotNull().GreaterThan(0).PrecisionScale(10, 2, false);
            RuleFor(x => x.Stock).GreaterThan(0).NotNull();
            RuleFor(x => x.CategoryId).NotNull();
        }
    }
}
