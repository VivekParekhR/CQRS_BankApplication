using Bank.Core.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using Bank.Core.ViewModel;
using Bank.Infrastructure.Persistence;

namespace Bank.Infrastructure.Repository
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
        public async Task<int> AddBankAsync(Domain.Entity.Bank bank)
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
        public async Task<Domain.Entity.Bank> GetBankByIdAsync(int id)
        {
            return await _dbContext.Banks  
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
