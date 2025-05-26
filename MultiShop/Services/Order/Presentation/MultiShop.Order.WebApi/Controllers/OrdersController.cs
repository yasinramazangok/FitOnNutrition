using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderList()
        {
            var values = await _mediator.Send(new GetOrderQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var values = await _mediator.Send(new GetOrderByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _mediator.Send(new DeleteOrderCommand(id));
            return Ok("Sipariş başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş başarıyla güncellendi");
        }
    }
}
