using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaecPinService.Services;

namespace WaecPinService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PinController : ControllerBase
    {

        private readonly IPinService _pinSerevice;

        public PinController(IPinService pinSerevice)
        {
            _pinSerevice = pinSerevice;
        }

        [HttpPost("generate")]
        public async Task<ActionResult<List<ScratchCard>>> GenerateCards(int quantity)
        {
            var cards = await _pinSerevice.GenerateCardsAsync(quantity);
            return Ok(cards);
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<ScratchCard>>> ListCards()
        {
            var cards = await _pinSerevice.ListCardsAsync();
            return Ok(cards);
        }

        [HttpPost("purchase")]
        public async Task<ActionResult<bool>> PurchaseCard(string cardId, string purchaserName)
        {
            var success = await _pinSerevice.PurchaseCardAsync(cardId, purchaserName);
            if (success)
            {
                return Ok(true);
            }
            return NotFound();
        }

        [HttpPost("use")]
        public async Task<ActionResult<string>> UseCard(string cardId)
        {
            var pin = await _pinSerevice.UseCardAsync(cardId);
            if (pin != null)
            {
                return Ok(pin);
            }
            return NotFound();
        }
    }
}
