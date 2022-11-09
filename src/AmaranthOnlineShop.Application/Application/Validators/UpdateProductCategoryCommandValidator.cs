using AmaranthOnlineShop.Application.Application.ProductCategories.Commands;
using FluentValidation;

namespace AmaranthOnlineShop.Application.Application.Validators
{
    public class UpdateProductCategoryCommandValidator : AbstractValidator<UpdateProductCategoryCommand>
    {
        public UpdateProductCategoryCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .Length(4, 100);
        }
    }
}
