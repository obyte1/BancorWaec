namespace WaecPinService.Model
{
    public class ScratchCard : EntityBase
    {
        public string Id { get; set; }
        public string Pin { get; set; }
        public string PurchaserName { get; set; }
        public CardStatus Status { get; set; }
    }

    public enum CardStatus
    {
        Available,
        Purchased,
        Used
    }
}
