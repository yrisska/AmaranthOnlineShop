using AmaranthOnlineShop.Application.Application.ProductCategories.Commands;
using AmaranthOnlineShop.Application.Application.ProductCategories.Queries;
using AmaranthOnlineShop.Application.Application.ProductCategories.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AmaranthOnlineShop.API.Controllers
{
    [Route("api/product-category")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductCategoryDto>> GetAllProductCategories()
        {
            var productCategories = await _mediator.Send(new GetAllProductCategoriesQuery());
            return productCategories;
        }

        [HttpGet("{id}")]
        public async Task<ProductCategoryDto> GetProductCategory(int id)
        {
            var productCategoryDto = await _mediator.Send(new GetProductCategoryByIdQuery() { ProductCategoryId = id });
            return productCategoryDto;
        }

        [HttpPost]
        public async Task<ProductCategoryDto> CreateProductCategory(CreateProductCategoryCommand productCategoryForCreateDto)
        {
            var productCategoryDto = await _mediator.Send(productCategoryForCreateDto);
            return productCategoryDto;
        } 

        [HttpPut]
        public async Task UpdateProductCategory(UpdateProductCategoryCommand productCategoryForUpdate)
        {
            await _mediator.Send(productCategoryForUpdate);
        }

        [HttpDelete("{id}")]
        public async Task DeleteProductCategory(int id)
        {
            await _mediator.Send(new DeleteProductCategoryCommand() {Id = id});
        }
    }
}
