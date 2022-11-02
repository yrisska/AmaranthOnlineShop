using AmaranthOnlineShop.Application.Application.Products.Commands;
using AmaranthOnlineShop.Application.Application.Products.Queries;
using AmaranthOnlineShop.Application.Application.Products.Responses;
using AmaranthOnlineShop.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace AmaranthOnlineShop.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("paginated-search")]
        public async Task<PaginatedResult<ProductListDto>> GetPagedProducts([FromQuery]ProductPagedRequest productPagedRequest)
        {
            var response = await _mediator.Send(new GetProductsPagedQuery { ProductPagedRequest = productPagedRequest });
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetProduct(int id)
        {
            var productDto = await _mediator.Send(new GetProductByIdQuery() {ProductId = id});
            return productDto;
        }

        [HttpPost]
        [Authorize("access:admin-data")]
        public async Task<ProductDto> CreateProduct(CreateProductCommand productForCreateDto)
        {
            var productDto = await _mediator.Send(productForCreateDto);
            return productDto;
        } 

        [HttpPut]
        [Authorize("access:admin-data")]
        public async Task UpdateProduct(UpdateProductCommand productForUpdate)
        {
            await _mediator.Send(productForUpdate);
        }

        [HttpDelete("{id}")]
        [Authorize("access:admin-data")]
        public async Task DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProductCommand() {Id = id});
        }
    }
}
