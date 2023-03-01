namespace Bank.Infrastructure.Exceptions
{
    [Serializable]
    public class InsufficientFundsException : Exception
    {
        // Constructor
        public InsufficientFundsException(string accountId, decimal amount)
        : base($"Account {accountId} does not have sufficient funds to transfer {amount:C}")
        {
        }
    } 
}