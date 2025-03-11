using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderResults;
using MultiShop.Order.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderHandlers
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, List<GetOrderQueryResult>>
    {
        private readonly IRepository<MultiShop.Order.Domain.Entities.Order> _orderRepository;

        public GetOrderQueryHandler(IRepository<Domain.Entities.Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<GetOrderQueryResult>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var values = await _orderRepository.GetListAllAsync();
            return values.Select(x => new GetOrderQueryResult
            {
                OrderId = x.OrderId,
                OrderDate = x.OrderDate,
                TotalPrice = x.TotalPrice,
                UserId = x.UserId
            }).ToList();
        }
    }
}
