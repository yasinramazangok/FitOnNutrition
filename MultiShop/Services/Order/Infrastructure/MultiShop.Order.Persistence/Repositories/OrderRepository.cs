using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Persistence.Context;

namespace MultiShop.Order.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _orderContext;

        public OrderRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public List<Domain.Entities.Order> GetOrdersByUserId(string id)
        {
            var values = _orderContext.Orders.Where(x => x.UserId == id).ToList();
            return values;
        }
    }
}
