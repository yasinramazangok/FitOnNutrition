using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.ProductDtos;
using MultiShop.DtoLayer.Dtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class ProductDetailImageSliderViewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductDetailImageSliderViewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/ProductImages/GetByProductIdProductImages?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetByIdProductImageDto>(result);
                return View(values);
            }
            return View();
        }
    }
}
