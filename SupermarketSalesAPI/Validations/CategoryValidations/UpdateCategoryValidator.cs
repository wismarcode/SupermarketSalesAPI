using FluentValidation;
using SupermarketSalesAPI.DTOs.CategoryDTOs;
namespace SupermarketSalesAPI.Validations.CategoryValidations
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(3, 50);
            RuleFor(x => x.Description).MaximumLength(100);
        }
    }
}
