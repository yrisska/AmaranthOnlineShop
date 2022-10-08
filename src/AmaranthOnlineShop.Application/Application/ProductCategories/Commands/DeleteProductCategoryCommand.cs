﻿using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Domain;
using MediatR;

namespace AmaranthOnlineShop.Application.Application.ProductCategories.Commands
{
    public class DeleteProductCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand>
    {
        private readonly IRepository _repository;

        public DeleteProductCategoryCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete<ProductCategory>(request.Id);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}