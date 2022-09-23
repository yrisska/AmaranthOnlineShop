using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Application.Application.Products.Commands
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
