using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.DiscountOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.DiscountOfferServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class DiscountOfferController : Controller
    {
        private readonly IDiscountOfferService _discountOfferService;

        public DiscountOfferController(IDiscountOfferService discountOfferService)
        {
            _discountOfferService = discountOfferService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "İndirim Teklif Listesi";
            ViewBag.v0 = "İndirim Teklif İşlemleri";

            var values = await _discountOfferService.GetAllDiscountOfferAsync();
            return View(values);
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

            await _discountOfferService.CreateDiscountOfferAsync(createDiscountOfferDto);
            return RedirectToAction("Index", "DiscountOffer", new { area = "Admin" });
        }

        public async Task<IActionResult> DeleteDiscountOffer(string id)
        {
            await _discountOfferService.DeleteDiscountOfferAsync(id);
            return RedirectToAction("Index", "DiscountOffer", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDiscountOffer(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = "İndirim Teklif Listesi";
            ViewBag.v0 = "İndirim Teklif İşlemleri";

            var values = await _discountOfferService.GetByIdDiscountOfferAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDiscountOffer(UpdateDiscountOfferDto updateDiscountOfferDto)
        {
            await _discountOfferService.UpdateDiscountOfferAsync(updateDiscountOfferDto);
            return RedirectToAction("Index", "DiscountOffer", new { area = "Admin" });
        }
    }
}
