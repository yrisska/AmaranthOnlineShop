using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Domain;
using AutoMapper;
using MediatR;

namespace AmaranthOnlineShop.Application.Application.ProductCategories.Commands
{
    public class UpdateProductCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public UpdateProductCategoryCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetById<ProductCategory>(request.Id);
            _mapper.Map(request, category);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
