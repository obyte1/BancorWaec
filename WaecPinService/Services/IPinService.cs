﻿using WaecPinService.Model;

namespace WaecPinService.Services
{
    public interface IPinService
    {
        Task<List<ScratchCard>> GenerateCardsAsync(int quantity, string purchasename);
        Task<List<ScratchCard>> ListCardsAsync();
        Task<bool> PurchaseCardAsync(string cardId, string purchaserName);
        Task<string> UseCardAsync(string cardId);
    }
}
