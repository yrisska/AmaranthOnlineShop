using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Application.Application.Orders.Commands
{
    public class MakeOrderCommandValidator : AbstractValidator<MakeOrderCommand>
    {
        public MakeOrderCommandValidator()
        {
            RuleForEach(x => x.CartItems)
                .NotEmpty()
                .SetValidator(new CartItemValidator());

            RuleFor(x => x.Email)
                .EmailAddress();
            RuleFor(x => x.Phone)
                .NotEmpty();
            RuleFor(x => x.Adress)
                .NotEmpty()
                .Length(10, 200);
            RuleFor(x => x.FullName)
                .Length(5, 200);
            RuleFor(x => x.Comments)
                .Length(0, 1000);
        }
    }
}
