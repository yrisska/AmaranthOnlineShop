using AmaranthOnlineShop.Application.Common.Models;
using FluentValidation;

namespace AmaranthOnlineShop.Application.Application.Validators
{
    public class CartItemValidator : AbstractValidator<CartItem>
    {
        public CartItemValidator()
        {
            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .LessThan(21);
        }
    }
}