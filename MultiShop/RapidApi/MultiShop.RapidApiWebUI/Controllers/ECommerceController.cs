using Microsoft.AspNetCore.Mvc;
using MultiShop.RapidApiWebUI.Models;
using Newtonsoft.Json;

namespace MultiShop.RapidApiWebUI.Controllers
{
    public class ECommerceController : Controller
    {
        public async Task<IActionResult> GetProductList()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-product-search.p.rapidapi.com/search-light-v2?q=logitech%20fare&country=tr&language=en&page=1&limit=10&sort_by=BEST_MATCH&product_condition=ANY&return_filters=false"),
                Headers =
                {
                    { "x-rapidapi-key", "16fc24c4demsh840d8502ff87770p1dd9d6jsn0227c1c19cf2" },
                    { "x-rapidapi-host", "real-time-product-search.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ProductViewModel.Rootobject>(body);
                return View(values.data.products.ToList());
            }
        }
    }
}
