using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderResults;
using MultiShop.Order.Application.Interfaces;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderHandlers
{
    public class GetOrderByUserIdQueryHandler : IRequestHandler<GetOrderByUserIdQuery, List<GetOrderByUserIdQueryResult>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByUserIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<GetOrderByUserIdQueryResult>> Handle(GetOrderByUserIdQuery request, CancellationToken cancellationToken)
        {
            var values = _orderRepository.GetOrdersByUserId(request.Id);
            return values.Select(x => new GetOrderByUserIdQueryResult
            {
                OrderDate = x.OrderDate,
                OrderId = x.OrderId,
                TotalPrice = x.TotalPrice,
                UserId = x.UserId
            }).ToList();
        }
    }
}
