using AmaranthOnlineShop.Application.Application.ProductCategories.Commands;
using FluentValidation;

namespace AmaranthOnlineShop.Application.Application.Validators
{
    public class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
    {
        public CreateProductCategoryCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .Length(4, 100);
        }
    }
}
