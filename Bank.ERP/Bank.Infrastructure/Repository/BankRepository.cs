using Bank.Core.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using Bank.Core.ViewModel;
using Bank.Infrastructure.Persistence;
using Bank.Domain.Entity;

namespace Bank.Infrastructure.Repository
{
    public class BankRepository : GenericRepository<Bank.Domain.Entity.Bank>, IBankRepository
    {
        #region Property
        private readonly BankDbContext _dbContext; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public BankRepository(BankDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
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
            var retval = Find(x => x.Name == bankName && x.BranchId == branchId).FirstOrDefault();
            if (retval != null)
            {
                retVal = false;
            }
            return retVal;
        }
    }
}
