using AmaranthOnlineShop.Application.Application.ProductCategories.Commands;
using AmaranthOnlineShop.Application.Application.ProductCategories.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IEnumerable<ProductCategoryListDto>> GetAllProductCategories()
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
        [Authorize("access:admin-data")]
        public async Task CreateProductCategory([FromQuery] CreateProductCategoryCommand productCategoryForCreateDto)
        {
            await _mediator.Send(productCategoryForCreateDto);
        } 

        [HttpPut]
        [Authorize("access:admin-data")]
        public async Task UpdateProductCategory([FromQuery] UpdateProductCategoryCommand productCategoryForUpdate)
        {
            await _mediator.Send(productCategoryForUpdate);
        }

        [HttpDelete("{id}")]
        [Authorize("access:admin-data")]
        public async Task DeleteProductCategory(int id)
        {
            await _mediator.Send(new DeleteProductCategoryCommand() {Id = id});
        }
    }
}
