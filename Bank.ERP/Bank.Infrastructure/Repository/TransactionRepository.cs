#region Using
using Bank.Core.Interface;
using Bank.Core.ViewModel;
using Bank.Domain.Entity;
using Bank.Domain.Enum;
using Bank.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates; 

#endregion

namespace Bank.Infrastructure.Repository
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
        public async Task<string> GetTransactionHistoryByAccountIdAsync(int BankId, int CustomerId) {

            var Iquery = _dbContext.Transactions.Include(x => x.Customer)
                                                       .Include(x => x.Bank)
                                                       .Where(x => x.BankId == BankId && x.CustomerId == CustomerId);

            List<TransactionHistory> lstTranHistory = new();
            var query = Iquery.Select(x => new TransactionHistory
            {
                Amount = x.Amount,
                Id = x.Id,
                TransactionId = x.TransactionId,
                TransactionType = Convert.ToString((TransactionType)x.TransactionType),
                TransectionDate = x.TransectionDate,
                TransectionRemarks = x.TransectionRemarks
            });
            lstTranHistory = await query.ToListAsync();
            TransactionHistoryViewModel objTransactionHistoryViewModel = new()
            {
                Transactions = lstTranHistory,
                Bank = Iquery.Select(x => x.Bank).FirstOrDefault(),
                Customer = Iquery.Select(x => x.Customer).FirstOrDefault()
            };
           
            return JsonConvert.SerializeObject(objTransactionHistoryViewModel);
        }
    }
}
