using FluentValidation;

namespace AmaranthOnlineShop.Application.Application.ProductCategories.Commands
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
