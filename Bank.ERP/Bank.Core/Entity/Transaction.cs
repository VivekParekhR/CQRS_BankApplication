namespace Bank.Core.Entity
{
    public class Transaction
    {
        public int Id { get; set; }
        public Guid TransactionId { get; set; }
        public decimal Amount { get; set; }
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public int BankId { get; set; }
    }
}
