using CarBookApp.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookApp.WebUI.Controllers
{
    public class CarPricingsWithCarsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarPricingsWithCarsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/CarPricings");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingsWithCarsDtos>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
