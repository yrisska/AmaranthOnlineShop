using AmaranthOnlineShop.Application.Application.Products.Commands;
using AmaranthOnlineShop.Application.Application.Products.Queries;
using AmaranthOnlineShop.Application.Application.Products.Responses;
using AmaranthOnlineShop.Application.Application.Profiles;
using AmaranthOnlineShop.Application.Common.Exceptions;
using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Application.Common.Models;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using Moq;
using System.Linq.Expressions;

namespace AmaranthOnlineShop.UnitTests.ApplicationTests
{
    public class ProductFixture
    {
        protected readonly Mock<IRepository> _repoMock;
        protected readonly IMapper _mapper;

        public ProductFixture()
        {
            _repoMock = new Mock<IRepository>();
            _mapper = new Mapper(new MapperConfiguration(x => x.AddProfile(new ProductProfile())));
        }
    }

    [CollectionDefinition("Product collection")]
    public class ProductCollection : ICollectionFixture<ProductFixture>
    { }

    #region GetProductByIdQuery
    [Collection("Product collection")]
    public class GetProductByIdQueryHandlerFixture : ProductFixture
    {
        private readonly GetProductByIdQueryHandler _handler;

        public GetProductByIdQueryHandlerFixture()
        {
            _handler = new GetProductByIdQueryHandler(_repoMock.Object, _mapper);
        }

        [Fact]
        public async Task GetProductByIdQueryHandler_WhenRequestIdFound_ReturnsDtoEntity()
        {
            var product = new Product
            {
                Id = 0,
                Name = "gel",
                Description = "description",
                Price = 10m,
                ProductCategory = new ProductCategory
                {
                    Id = 1,
                    Name = "bath",
                },
                ProductCategoryId = 1,
            };
            _repoMock.Setup(x =>
                    x.GetByIdWithInclude(
                        It.IsAny<int>(),
                        It.IsAny<Expression<Func<Product, object>>>())
                    ).ReturnsAsync(product);

            var productDto = await _handler.Handle(new GetProductByIdQuery { ProductId = product.Id },
                default);

            _repoMock.Verify(x =>
                x.GetByIdWithInclude(
                    It.IsAny<int>(),
                    It.IsAny<Expression<Func<Product, object>>>()),
                Times.Once()
            );
            Assert.NotNull(productDto);
            Assert.Equal(product.Name, productDto.Name);
            Assert.Equal(product.Price, productDto.Price);
            Assert.Equal(product.Description, productDto.Description);
            Assert.Equal(product.Id, productDto.Id);
            Assert.Equal(product.ProductCategoryId, productDto.ProductCategoryId);
        }
        [Fact]
        public async Task GetProductByIdQueryHandler_WhenRequestIdNotFound_ReturnsNull()
        {
            _repoMock.Setup(x =>
                x.GetByIdWithInclude(
                    It.IsAny<int>(),
                    It.IsAny<Expression<Func<Product, object>>>())
            ).ReturnsAsync(value: null);

            var productDto = await _handler.Handle(new GetProductByIdQuery { ProductId = 242561 },
                default);

            _repoMock.Verify(x =>
                    x.GetByIdWithInclude(
                        It.IsAny<int>(),
                        It.IsAny<Expression<Func<Product, object>>>()),
                Times.Once()
            );
            Assert.Null(productDto);
        }
    }
    #endregion

    #region GetProductsPagedQuery
    [Collection("Product collection")]
    public class GetProductsPagedQueryFixture : ProductFixture
    {
        private readonly GetProductsPagedQueryHandler _handler;
        public GetProductsPagedQueryFixture()
        {
            _handler = new GetProductsPagedQueryHandler(_repoMock.Object, _mapper);
        }
        [Fact]
        public async Task GetProductsPagedQueryHandler_ReturnsPagedData()
        {
            var request = new GetProductsPagedQuery
            {
                ProductPagedRequest = new ProductPagedRequest()
            };
            var expected = new PaginatedResult<ProductListDto>
            {
                PageSize = 10,
                PageIndex = 1,
                Total = 10,
                Items = new List<ProductListDto>()
                {
                    new ProductListDto{Id = 1}
                }
            };
            _repoMock.Setup(x => x.GetPagedData<Product, ProductListDto>(It.IsAny<ProductPagedRequest>())).ReturnsAsync(expected);

            var result = await _handler.Handle(request, default);

            _repoMock.Verify(x => x.GetPagedData<Product, ProductListDto>(It.IsAny<ProductPagedRequest>()), Times.Once);
            Assert.Equal(expected, result);
        }
    }
    #endregion

    #region CreateProductCommand
    [Collection("Product collection")]
    public class CreateProductCommandHandlerFixture : ProductFixture
    {
        private readonly CreateProductCommandHandler _handler;

        public CreateProductCommandHandlerFixture()
        {
            _handler = new CreateProductCommandHandler(_repoMock.Object, _mapper);
        }

        [Fact]
        public async Task CreateProductCommandHandler_WhenAddProduct_ReturnsProductDto()
        {
            var createProductRequest = new CreateProductCommand()
            {
                Name = "prod1",
                Description = "desc1",
                Price = 11m,
                ProductCategoryId = 1,
            };

            var product = await _handler.Handle(createProductRequest, default);

            _repoMock.Verify(x => x.Add(It.IsAny<Product>()), Times.Once);
            _repoMock.Verify(x => x.SaveChangesAsync(), Times.Once);

            Assert.NotNull(product);
            Assert.Equal(createProductRequest.Name, product.Name);
            Assert.Equal(createProductRequest.Description, product.Description);
            Assert.Equal(createProductRequest.Price, product.Price);
            Assert.Equal(createProductRequest.ProductCategoryId, product.ProductCategoryId);
        }
    }
    #endregion

    #region DeleteProductCommand
    [Collection("Product collection")]
    public class DeleteProductCommandFixture : ProductFixture
    {
        private readonly DeleteProductCommandHandler _handler;

        public DeleteProductCommandFixture()
        {
            _handler = new DeleteProductCommandHandler(_repoMock.Object);
        }

        [Fact]
        public async Task DeleteProductCommandHandler_WhenRequestIdFound_DeletesEntity()
        {
            await _handler.Handle(new DeleteProductCommand{Id = 1}, default);

            _repoMock.Verify(x => x.Delete<Product>(It.IsAny<int>()), Times.Once);
            _repoMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }
        [Fact]
        public async Task DeleteProductCommandHandler_WhenRequestIdNotFound_ThrowsException()
        {
            _repoMock.Setup(x => x.Delete<Product>(It.IsAny<int>()))
                .ThrowsAsync(new EntityNotFoundException("Id not found"));

            await Assert.ThrowsAsync<EntityNotFoundException>(async () =>
                await _handler.Handle(new DeleteProductCommand {Id = 1}, default));
            
            _repoMock.Verify(x => x.Delete<Product>(It.IsAny<int>()), Times.Once);
            _repoMock.Verify(x => x.SaveChangesAsync(), Times.Never);
        }
    }
    #endregion

    #region UpdateProduct
    [Collection("Product collection")]
    public class UpdateProductCommandFixture : ProductFixture
    {
        private readonly UpdateProductCommandHandler _handler;
        public UpdateProductCommandFixture()
        {
            _handler = new UpdateProductCommandHandler(_repoMock.Object, _mapper);
        }
        [Fact]
        public async Task UpdateProductCommandHandler_WhenEntityFound_UpdatesEntity()
        {
            var product = new Product
            {
                Id = 0,
                Name = "gel",
                Description = "description",
                Price = 10m,
                ProductCategory = new ProductCategory
                {
                    Id = 1,
                    Name = "bath",
                },
                ProductCategoryId = 1,
            };
            _repoMock.Setup(x => x.GetById<Product>(It.IsAny<int>())).ReturnsAsync(product);
            
            await _handler.Handle(new UpdateProductCommand {
                Id = 0,
                Description = "desc",
                Name = "name",
                Price = 5m,
                ProductCategoryId = 2
            }, default);

            _repoMock.Verify(x => x.GetById<Product>(It.IsAny<int>()), Times.Once);
            _repoMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }
        [Fact]
        public async Task UpdateProductCommandHandler_WhenEntityNotFound_ThrowsExcepion()
        {
            var command = new UpdateProductCommand { Id = 1 };
            _repoMock.Setup(x => x.GetById<Product>(It.IsAny<int>())).ReturnsAsync(value: null);

            await Assert.ThrowsAnyAsync<EntityNotFoundException>(async () => await _handler.Handle(command, default));
            _repoMock.Verify(x => x.GetById<Product>(It.IsAny<int>()), Times.Once);
        }
    }
    #endregion
}
