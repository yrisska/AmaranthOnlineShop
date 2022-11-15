using AmaranthOnlineShop.Application.Application.Products.Commands;
using FluentValidation;

namespace AmaranthOnlineShop.Application.Application.Validators
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .Length(4, 100);
            RuleFor(p => p.Description)
                .Length(8, 1000);
            RuleFor(p => p.Price)
                .GreaterThan(0);
        }
    }
}
