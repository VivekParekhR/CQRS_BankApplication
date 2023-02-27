#region Using
using Bank.Core.Entity; 
#endregion

namespace Bank.Core.Interface
{
    public interface ITransactionRepository
    {
        Task<int> AddTransactionAsync(Transaction transaction);
        Task<Transaction> GetTransactionByIdAsync(int id);
    }
}
