using AmaranthOnlineShop.Application.Application.Products.Commands;
using FluentValidation;

namespace AmaranthOnlineShop.Application.Application.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .Length(4, 100);
            RuleFor(p => p.Description)
                .NotEmpty()
                .Length(8, 1000);
            RuleFor(p => p.Price)
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(p => p.ProductCategoryId)
                .NotEmpty();
        }
    }
}