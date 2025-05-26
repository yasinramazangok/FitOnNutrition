using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderCommands;
using MultiShop.Order.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderHandlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IRepository<MultiShop.Order.Domain.Entities.Order> _orderRepository;

        public UpdateOrderCommandHandler(IRepository<Domain.Entities.Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var values = await _orderRepository.GetByIdAsync(request.OrderId);
            values.OrderDate = request.OrderDate;
            values.TotalPrice = request.TotalPrice;
            values.UserId = request.UserId;
            await _orderRepository.UpdateAsync(values);
        }
    }
}
