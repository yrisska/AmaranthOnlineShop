using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Domain;
using MediatR;

namespace AmaranthOnlineShop.Application.Application.Products.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IRepository _repository;
        private readonly ICloudStorage _cloudStorage;

        public DeleteProductCommandHandler(IRepository repository, ICloudStorage cloudStorage)
        {
            _repository = repository;
            _cloudStorage = cloudStorage;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.Delete<Product>(request.Id);
            await _repository.SaveChangesAsync();

            await _cloudStorage.DeleteAsync(Path.GetFileName(product.ImageUri));

            return Unit.Value;
        }
    }
}
