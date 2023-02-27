#region Using
using Bank.Core.Context;
using Bank.Core.Entity;
using Bank.Core.Interface;
using Bank.Core.ViewModel;
using Microsoft.EntityFrameworkCore; 
#endregion

namespace Bank.Core.Repository
{
    public class TransactionHistoryRepository : ITransactionHistoryRepository
    {

        #region Property
        private readonly BankDbContext _dbContext;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public TransactionHistoryRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// AddTransactionHistoryAsync
        /// </summary>
        /// <param name="transactionHistory"></param>
        /// <returns></returns>
        public async Task<int> AddTransactionHistoryAsync(TransactionHistory transactionHistory)
        {
            await _dbContext.TransactionHistories.AddAsync(transactionHistory);
            await _dbContext.SaveChangesAsync();
            return transactionHistory.Id;
        }

        /// <summary>
        /// GetTransactionHistoryByAccountIdAsync
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public async Task<TransactionHistoryViewModel> GetTransactionHistoryByAccountIdAsync(Guid accountNumber)
        {
            TransactionHistoryViewModel obj = new TransactionHistoryViewModel();
            List<TransactionHistory> lsHistory = new List<TransactionHistory>();
            lsHistory = await _dbContext.TransactionHistories
                                   .Where(t => t.Account.AccountNumber == accountNumber).ToListAsync();
            var abl = await _dbContext.Accounts.Where(x => x.AccountNumber == accountNumber).Select(x => x.Balance).FirstOrDefaultAsync();
            obj.TransactionHistory = lsHistory;
            obj.AccountBalance = abl;
            obj.AccountNumber = accountNumber;
            return obj;

        }
    }
}
