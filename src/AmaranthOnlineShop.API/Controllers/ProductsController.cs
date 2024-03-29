﻿using AmaranthOnlineShop.Application.Application.Products.Commands;
using AmaranthOnlineShop.Application.Application.Products.Queries;
using AmaranthOnlineShop.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<PaginatedResult<ProductPagedDto>> GetPagedProducts(
            [FromQuery] ProductPagedRequest productPagedRequest)
        {
            var response = await _mediator.Send(new GetProductsPagedQuery { ProductPagedRequest = productPagedRequest });
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetProduct(int id)
        {
            var productDto = await _mediator.Send(new GetProductByIdQuery() { ProductId = id });
            return productDto;
        }

        [HttpPost]
        [Authorize("access:admin-data")]
        public async Task<ProductCreatedDto> CreateProduct([FromForm] CreateProductCommand productForCreateDto)
        {
            var productCreatedDto = await _mediator.Send(productForCreateDto);
            return productCreatedDto;
        }

        [HttpPut]
        [Authorize("access:admin-data")]
        public async Task<ProductUpdatedDto> UpdateProduct([FromForm] UpdateProductCommand productForUpdate)
        {
            var productUpdatedDto = await _mediator.Send(productForUpdate);
            return productUpdatedDto;
        }

        [HttpDelete("{id}")]
        [Authorize("access:admin-data")]
        public async Task<ProductDeletedDto> DeleteProduct(int id)
        {
            var productDeletedDto = await _mediator.Send(new DeleteProductCommand() { Id = id });
            return productDeletedDto;
        }
    }
}