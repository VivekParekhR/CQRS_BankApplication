using Bank.Core.Context;
using Bank.Core.Entity;
using Bank.Core.Interface;
using Bank.Infrastructure.Enum;
using Microsoft.EntityFrameworkCore;
using System; 
using Bank.Core.ViewModel;

namespace Bank.Core.Repository
{
    public class BankRepository : IBankRepository
    {
        #region Property
        private readonly BankDbContext _dbContext; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public BankRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// AddBankAsync
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public async Task<int> AddBankAsync(Entity.Bank bank)
        {
            await _dbContext.Banks.AddAsync(bank);
            await _dbContext.SaveChangesAsync();
            return bank.Id;
        }

        /// <summary>
        /// GetBankByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Entity.Bank> GetBankByIdAsync(int id)
        {
            return await _dbContext.Banks
                                   .Include(x => x.Customers)
                                   .Include(x=>x.Transactions)
                                   .Where(x=>x.Id==id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// CheckBankExists
        /// </summary>
        /// <param name="bankName"></param>
        /// <param name="branchId"></param>
        /// <returns></returns>
        public bool CheckBankExists(string bankName,int branchId)
        {
            bool retVal = true;
            var retval = _dbContext.Banks.Where(x => x.Name == bankName && x.BranchId == branchId).FirstOrDefault();
            if (retval != null)
            {
                retVal = false;
            }
            return retVal;
        }
    }
}
