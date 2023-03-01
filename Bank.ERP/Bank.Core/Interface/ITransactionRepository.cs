#region Using
using Azure.Core;
using Bank.Core.Entity;
using Bank.Core.ViewModel;
#endregion

namespace Bank.Core.Interface
{
    public interface ITransactionRepository
    {
        Task<int> AddTransactionAsync(Transaction transaction);
        Task<Transaction> GetTransactionByIdAsync(int id);
        Task<TransactionHistoryViewModel> GetTransactionHistoryByAccountIdAsync(int BankId, int CustomerId);
    }
}
