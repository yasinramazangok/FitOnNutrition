﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.FeatureDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class DefaultFeaturedViewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultFeaturedViewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var result = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(result);
                return View(values);
            }
            return View();
        }
    }
}
