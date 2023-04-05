#region Using
using Azure.Core;
using Bank.Domain.Entity;
using Bank.Domain.Interface;

#endregion

namespace Bank.Domain.Interface
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    { 
        Task<string> GetTransactionHistoryByAccountIdAsync(int BankId, int CustomerId); //To do view model
    }
}
