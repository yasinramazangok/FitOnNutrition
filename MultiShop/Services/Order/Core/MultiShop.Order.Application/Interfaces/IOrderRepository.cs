namespace MultiShop.Order.Application.Interfaces
{
    public interface IOrderRepository
    {
        public List<Domain.Entities.Order> GetOrdersByUserId(string id);
    }
}
