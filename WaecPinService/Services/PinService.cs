using Microsoft.AspNetCore.SignalR;
using WaecPinService.DataAccess;
using WaecPinService.Model;

namespace WaecPinService.Services
{

    public class PinService : IPinService
    {
        private readonly IRepository<ScratchCard> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PinService(IRepository<ScratchCard> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ScratchCard>> GenerateCardsAsync(int quantity)
        {
            var cards = new List<ScratchCard>();
            for (int i = 0; i < quantity; i++)
            {
                var card = new ScratchCard
                {
                    Id = Guid.NewGuid().ToString(),
                    Pin = GenerateRandomPin(), // Implement your PIN generation logic
                    Status = CardStatus.Available
                };
                cards.Add(card);
                await _repository.InsertAsync(card);
            }
            await _unitOfWork.SaveChangesAsync();
            return cards;
        }

        public async Task<List<ScratchCard>> ListCardsAsync()
        {
            return (List<ScratchCard>)await _repository.GetAllAsync();
        }

        public async Task<bool> PurchaseCardAsync(string cardId, string purchaserName)
        {
            var card = await _repository.GetFirstAsync(x => x.Id == cardId);
            if (card != null && card.Status == CardStatus.Available)
            {
                card.PurchaserName = purchaserName;
                card.Status = CardStatus.Purchased;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<string> UseCardAsync(string cardId)
        {
            var card = await _repository.GetFirstAsync(x => x.Id == cardId);
            if (card != null && card.Status == CardStatus.Purchased)
            {
                card.Status = CardStatus.Used;
                await _unitOfWork.SaveChangesAsync();
                return card.Pin;
            }
            return null;
        }

        private string GenerateRandomPin()
        {
            return Guid.NewGuid().ToString().Substring(0, 8);
        }
    }
}