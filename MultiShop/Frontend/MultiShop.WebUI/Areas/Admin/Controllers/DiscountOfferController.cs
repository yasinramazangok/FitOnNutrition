using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.DiscountOfferDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [AllowAnonymous]
    public class DiscountOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DiscountOfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "İndirim Teklif Listesi";
            ViewBag.v0 = "İndirim Teklif İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/DiscountOffers");
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDiscountOfferDto>>(result);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateDiscountOffer()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "İndirim Teklif Listesi";
            ViewBag.v0 = "İndirim Teklif İşlemleri";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountOffer(CreateDiscountOfferDto createDiscountOfferDto)
        {
            /*
            var currentCount = _offerDiscountService.TGetAll().Count;
            if (currentCount >= 2)
            {
                TempData["ErrorMessage"] = "Maksimum 2 indirim teklifi eklenebilir.";
                return RedirectToAction("Index");
            }
            */

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createDiscountOfferDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/DiscountOffers", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "DiscountOffer", new { area = "Admin" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteDiscountOffer(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7070/api/DiscountOffers/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "DiscountOffer", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDiscountOffer(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "İndirim Teklif Listesi";
            ViewBag.v0 = "İndirim Teklif İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/DiscountOffers/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateDiscountOfferDto>(result);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDiscountOffer(UpdateDiscountOfferDto updateDiscountOfferDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateDiscountOfferDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/DiscountOffers", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "DiscountOffer", new { area = "Admin" });
            }
            return View();
        }
    }
}
