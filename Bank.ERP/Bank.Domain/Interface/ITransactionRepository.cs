#region Using
using Azure.Core;
using Bank.Domain.Entity;
using Bank.Domain.Interface;

#endregion

namespace Bank.Core.Interface
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        Task<int> AddTransactionAsync(Transaction transaction);
        Task<Transaction> GetTransactionByIdAsync(int id);
        Task<string> GetTransactionHistoryByAccountIdAsync(int BankId, int CustomerId); //To do view model
    }
}
