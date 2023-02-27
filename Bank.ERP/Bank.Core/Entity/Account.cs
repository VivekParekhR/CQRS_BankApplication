#region Using
using Bank.Infrastructure.Enum;

#endregion
namespace Bank.Core.Entity
{
    public class Account
    {
        public int Id { get; set; }
        public Guid AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        public AccountType AccountType { get; set; }
    }
}
