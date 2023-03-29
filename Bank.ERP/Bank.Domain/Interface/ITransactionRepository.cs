#region Using
using Azure.Core;
using Bank.Domain.Entity; 
#endregion

namespace Bank.Core.Interface
{
    public interface ITransactionRepository
    {
        Task<int> AddTransactionAsync(Transaction transaction);
        Task<Transaction> GetTransactionByIdAsync(int id);
        Task<string> GetTransactionHistoryByAccountIdAsync(int BankId, int CustomerId); //To do view model
    }
}
