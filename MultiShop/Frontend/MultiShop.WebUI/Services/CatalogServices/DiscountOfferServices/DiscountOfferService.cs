using MultiShop.DtoLayer.Dtos.DiscountOfferDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.DiscountOfferServices
{
    public class DiscountOfferService : IDiscountOfferService
    {
        private readonly HttpClient _httpClient;

        public DiscountOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateDiscountOfferAsync(CreateDiscountOfferDto createDiscountOfferDto)
        {
            await _httpClient.PostAsJsonAsync<CreateDiscountOfferDto>("discountoffers", createDiscountOfferDto);
        }

        public async Task DeleteDiscountOfferAsync(string id)
        {
            await _httpClient.DeleteAsync("discountoffers/" + id);
        }

        public async Task<UpdateDiscountOfferDto> GetByIdDiscountOfferAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("discountoffers/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateDiscountOfferDto>();
            return values;
        }

        public async Task<List<ResultDiscountOfferDto>> GetAllDiscountOfferAsync()
        {
            var responseMessage = await _httpClient.GetAsync("discountoffers");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultDiscountOfferDto>>(jsonData);
            return values;
        }

        public async Task UpdateDiscountOfferAsync(UpdateDiscountOfferDto updateDiscountOfferDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateDiscountOfferDto>("discountoffers", updateDiscountOfferDto);
        }
    }
}
