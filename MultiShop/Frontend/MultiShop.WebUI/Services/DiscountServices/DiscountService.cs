using MultiShop.DtoLayer.Dtos.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetCouponCodeDetailByCode> GetCouponCodeDetailByCode(string code)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7071/api/Coupons/GetCouponCodeDetailByCode?code=" + code);
            var values = await responseMessage.Content.ReadFromJsonAsync<GetCouponCodeDetailByCode>();
            return values;
        }

        public async Task<int> GetCouponRateByCodeAsync(string code)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7071/api/Coupons/GetCouponRateByCode?code=" + code);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
