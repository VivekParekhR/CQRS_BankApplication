#region Using
using Bank.Core.Context;
using Bank.Core.Entity;
using Bank.Core.Interface;
using Bank.Core.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Transaction = Bank.Core.Entity.Transaction;

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
        public async Task<TransactionHistoryViewModel> GetTransactionHistoryByAccountIdAsync(int BankId, int CustomerId) {

            IEnumerable<Transaction> Iquery = _dbContext.Transactions
                                                       .Include(x => x.customer)
                                                       .Include(x => x.bank)
                                                       .Where(x => x.BankId == BankId && x.CustomerId == CustomerId);

            List<TransactionHistory> lstTranHistory = new List<TransactionHistory>();
            lstTranHistory = Iquery.Select(x => new TransactionHistory { Amount=x.Amount,
                                                                         Id=x.Id,
                                                                         TransactionId=x.TransactionId,
                                                                         TransactionType= Convert.ToString((Infrastructure.Enum.TransactionType)x.TransactionType),
                                                                         TransectionDate=x.TransectionDate,
                                                                         TransectionRemarks =x.TransectionRemarks}).ToList();
            TransactionHistoryViewModel objTransactionHistoryViewModel = new TransactionHistoryViewModel()
            {
                Transactions = lstTranHistory,
                Bank = Iquery.Select(x => x.bank).FirstOrDefault(),
                Customer = Iquery.Select(x => x.customer).FirstOrDefault()
            };
             

            return objTransactionHistoryViewModel;
        }
    }
}
