#region Using
using Bank.Domain.Entity;

#endregion
namespace Bank.Core.ViewModel
{
    public class TransactionHistoryViewModel
    { 
        public Bank.Domain.Entity.Bank Bank { get; set; }
        public Customer Customer { get; set; }
        public List<TransactionHistory> Transactions { get; set; } 
    } 
}
