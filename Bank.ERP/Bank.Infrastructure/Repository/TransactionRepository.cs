#region Using 
using Bank.Domain.Entity;
using Bank.Domain.Enum;
using Bank.Domain.Interface;
using Bank.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json; 
#endregion

namespace Bank.Infrastructure.Repository
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        #region Property
        private readonly BankDbContext _dbContext;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public TransactionRepository(BankDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }  

        public async Task<string> GetTransactionHistoryByAccountIdAsync(int BankId, int CustomerId) {

            var Iquery = _dbContext.Transactions.Include(x => x.Customer)
                                                       .Include(x => x.Bank)
                                                       .Where(x => x.BankId == BankId && x.CustomerId == CustomerId);
             
            var query = Iquery.Select(x => new
            {
                Amount = x.Amount,
                Id = x.Id,
                TransactionId = x.TransactionId,
                TransactionType = Convert.ToString((TransactionType)x.TransactionType),
                TransectionDate = x.TransectionDate,
                TransectionRemarks = x.TransectionRemarks
            });

            var lstTranHistory = await query.ToListAsync();

            var objTransactionHistoryViewModel = new
            {
                Transactions = lstTranHistory,
                Bank = Iquery.Select(x => x.Bank).FirstOrDefault(),
                Customer = Iquery.Select(x => x.Customer).FirstOrDefault()
            };
           
            return JsonConvert.SerializeObject(objTransactionHistoryViewModel);
        }
    }
}
