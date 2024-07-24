using FrontEnd.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace FrontEnd.Controllers
{
    public class PinController : Controller
    {
        private readonly HttpClient _httpClient;

        public PinController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://yourapiendpoint.com/api/"); // Replace with your API base URL
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        private readonly PinService _pinService;

        public PinController(PinService pinService)
        {
            _pinService = pinService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GenerateCards(int quantity, string purchaserName)
        {
            var cards = await _pinService.GenerateCardsAsync(quantity, purchaserName);
            return View(cards);
        }

        [HttpGet]
        public async Task<IActionResult> ListCards()
        {
            var cards = await _pinService.ListCardsAsync();
            return View(cards);
        }

        [HttpPost]
        public async Task<IActionResult> PurchaseCard(string cardId, string purchaserName)
        {
            var success = await _pinService.PurchaseCardAsync(cardId, purchaserName);
            if (success)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UseCard(string cardId)
        {
            var pin = await _pinService.UseCardAsync(cardId);
            if (pin != null)
            {
                ViewBag.Pin = pin;
                return View();
            }
            return NotFound();
        }
    }

}
