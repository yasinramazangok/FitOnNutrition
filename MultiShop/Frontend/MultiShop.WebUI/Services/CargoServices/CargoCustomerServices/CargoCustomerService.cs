using MultiShop.DtoLayer.Dtos.CargoDtos.CargoCustomerDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;

        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetCargoCustomerByUserIdDto> GetCargoCustomerInfoAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"cargocustomers/GetCargoCustomerByUserId/{id}");
            var values = await responseMessage.Content.ReadFromJsonAsync<GetCargoCustomerByUserIdDto>();
            return values;
        }
    }
}
