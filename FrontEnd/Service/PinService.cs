using FrontEnd.Models;

namespace FrontEnd.Service
{
    public class PinService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:5001/api/pin"; // Update with your API base URL

        public PinService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<ScratchCard>> GenerateCardsAsync(int quantity, string purchaserName)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/generate?quantity={quantity}&purchasename={purchaserName}", null);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<ScratchCard>>();
        }

        public async Task<List<ScratchCard>> ListCardsAsync()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/list");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<ScratchCard>>();
        }

        public async Task<bool> PurchaseCardAsync(string cardId, string purchaserName)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/purchase?cardId={cardId}&purchasername={purchaserName}", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<string> UseCardAsync(string cardId)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/use?cardId={cardId}", null);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }

}
