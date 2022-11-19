using AmaranthOnlineShop.Application.Application.ProductCategories.Commands;
using AmaranthOnlineShop.Application.Application.ProductCategories.Queries;
using AmaranthOnlineShop.Application.Common.Models;
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

        [HttpGet("paginated-search")]
        public async Task<PaginatedResult<ProductCategoryPagedDto>> GetPagedProductCategories(
            [FromQuery] ProductCategoriesPagedRequest request)
        {
            var productCategories = await _mediator.Send(new GetPagedProductCategoriesQuery
            { ProductCategoriesPagedRequest = request });
            return productCategories;
        }

        [HttpGet("{id}")]
        public async Task<ProductCategoryDto> GetProductCategory(int id)
        {
            var productCategoryDto = await _mediator.Send(new GetProductCategoryByIdQuery() { ProductCategoryId = id });
            return productCategoryDto;
        }

        [HttpGet("many")]
        public async Task<IEnumerable<ProductCategoryListDto>> GetManyProductCategories([FromQuery] int[] identifiers)
        {
            var productCategoryListDto =
                await _mediator.Send(new GetManyProductCategoriesQuery() { Identifiers = identifiers });
            return productCategoryListDto;
        }

        [HttpPost]
        [Authorize("access:admin-data")]
        public async Task<ProductCategoryCreatedDto> CreateProductCategory(
            [FromQuery] CreateProductCategoryCommand productCategoryForCreateDto)
        {
            var productCategoryCreatedDto = await _mediator.Send(productCategoryForCreateDto);
            return productCategoryCreatedDto;
        }

        [HttpPut]
        [Authorize("access:admin-data")]
        public async Task<ProductCategoryUpdatedDto> UpdateProductCategory(
            [FromQuery] UpdateProductCategoryCommand productCategoryForUpdate)
        {
            var productCategoryUpdatedDto = await _mediator.Send(productCategoryForUpdate);
            return productCategoryUpdatedDto;
        }

        [HttpDelete("{id}")]
        [Authorize("access:admin-data")]
        public async Task<ProductCategoryDeletedDto> DeleteProductCategory(int id)
        {
            var productCategoryDeletedDto = await _mediator.Send(new DeleteProductCategoryCommand() { Id = id });
            return productCategoryDeletedDto;
        }
    }
}