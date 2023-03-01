#region Using
using Bank.Core.Entity;

#endregion
namespace Bank.Core.ViewModel
{
    public class TransactionHistoryViewModel
    { 
        public Entity.Bank Bank { get; set; }
        public Customer Customer { get; set; }
        public List<TransactionHistory> Transactions { get; set; } 
    } 
}
