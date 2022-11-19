using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Domain;
using MediatR;

namespace AmaranthOnlineShop.Application.Application.Orders.Commands
{
    public class UpdateOrderStatusCommand : IRequest
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
    }

    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand>
    {
        private readonly IPaymentProvider _paymentProvider;
        private readonly IRepository _repository;

        public UpdateOrderStatusCommandHandler(IPaymentProvider paymentProvider, IRepository repository)
        {
            _paymentProvider = paymentProvider;
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetById<OrderDetail>(request.OrderId);

            order.Status = request.Status;
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}