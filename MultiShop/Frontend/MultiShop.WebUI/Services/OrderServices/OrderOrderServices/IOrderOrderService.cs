using MultiShop.DtoLayer.Dtos.OrderDtos.OrderOrderDtos;
namespace MultiShop.WebUI.Services.OrderServices.OrderOrderServices
{
    public interface IOrderOrderService
    {
        Task<List<ResultOrdersByUserIdDto>> GetOrdersByUserId(string id);
    }
}
