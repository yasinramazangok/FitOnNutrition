using Microsoft.AspNetCore.Mvc;
using MultiShop.RapidApiWebUI.Models;
using Newtonsoft.Json;

namespace MultiShop.RapidApiWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public async Task<IActionResult> GetWeatherDetail()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://the-weather-api.p.rapidapi.com/api/weather/ankara"),
                Headers =
                {
                    { "x-rapidapi-key", "16fc24c4demsh840d8502ff87770p1dd9d6jsn0227c1c19cf2" },
                    { "x-rapidapi-host", "the-weather-api.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<WeatherViewModel.Rootobject>(body);
                ViewBag.cityTemperature = values.data.temp;
                return View(values);
            }
        }

        public async Task<ActionResult> Exchange()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&to_symbol=TRY&language=en"),
                Headers =
                {
                    { "x-rapidapi-key", "16fc24c4demsh840d8502ff87770p1dd9d6jsn0227c1c19cf2" },
                    { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(body);
                ViewBag.exchangeRateUSD = values.data.exchange_rate;
                ViewBag.previous_closeUSD = values.data.previous_close;
            }

            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=EUR&to_symbol=TRY&language=en"),
                Headers =
                {
                    { "x-rapidapi-key", "16fc24c4demsh840d8502ff87770p1dd9d6jsn0227c1c19cf2" },
                    { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
                },
            };
            using (var response = await client2.SendAsync(request2))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(body);
                ViewBag.exchangeRateEUR = values.data.exchange_rate;
                ViewBag.previous_closeEUR = values.data.previous_close;
                return View(values);
            }
        }
    }
}
