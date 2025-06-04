using Newtonsoft.Json;
using MultiShop.DtoLayer.Dtos.OrderDtos.OrderOrderDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderOrderServices
{
    public class OrderOrderService : IOrderOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderOrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultOrdersByUserIdDto>> GetOrdersByUserId(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"orders/GetOrdersByUserId/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultOrdersByUserIdDto>>(jsonData);
            return values;
        }
    }
}
