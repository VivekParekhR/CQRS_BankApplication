namespace Bank.Core.Entity
{
    public class TransactionHistory
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
