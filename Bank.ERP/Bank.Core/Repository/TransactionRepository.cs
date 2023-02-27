#region Using
using Bank.Core.Context;
using Bank.Core.Entity;
using Bank.Core.Interface; 
#endregion

namespace Bank.Core.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        #region Property
        private readonly BankDbContext _dbContext;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public TransactionRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// AddTransactionAsync
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<int> AddTransactionAsync(Transaction transaction)
        {
            await _dbContext.Transactions.AddAsync(transaction);
            await _dbContext.SaveChangesAsync();
            return transaction.Id;
        }

        /// <summary>
        /// GetTransactionByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            return await _dbContext.Transactions.FindAsync(id);
        }
    }
}
