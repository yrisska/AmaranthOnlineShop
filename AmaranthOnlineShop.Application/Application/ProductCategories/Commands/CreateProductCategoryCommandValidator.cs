using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmaranthOnlineShop.Application.Application.ProductCategories.Commands
{
    public class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
    {
        public CreateProductCategoryCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .Length(4, 100);
            RuleFor(p => p.Description)
                .NotEmpty()
                .Length(8, 1000);
        }
    }
}
