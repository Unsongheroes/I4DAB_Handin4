namespace TraderInfo.Models
{
    public class Transaction
    {
        public string TransactionId { get; set; }
        public int AmountOfPowerBought { get; set; }
        public int BuyingPosumerId { get; set; }
        public int SellingPosumerId { get; set; }
        public bool Spent { get; set; }
    }
}