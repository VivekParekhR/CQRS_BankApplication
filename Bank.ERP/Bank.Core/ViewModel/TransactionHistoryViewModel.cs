#region Using
using Bank.Core.Entity; 
#endregion

namespace Bank.Core.ViewModel
{
    public class TransactionHistoryViewModel
    {
        public Guid AccountNumber { get; set; }
        public TransactionHistoryViewModel()
        {
            TransactionHistory = new List<TransactionHistory>();
        }
        public List<TransactionHistory> TransactionHistory { get; set; }

        public decimal AccountBalance { get; set; }
    }
}
