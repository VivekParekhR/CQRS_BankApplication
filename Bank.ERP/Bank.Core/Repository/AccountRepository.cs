#region Using
using Bank.Core.Context;
using Bank.Core.Entity;
using Bank.Core.Interface;
using Bank.Infrastructure.Enum;
using Microsoft.EntityFrameworkCore; 
#endregion
namespace Bank.Core.Repository
{
    public class AccountRepository : IAccountRepository
    {
        #region Property
        private readonly BankDbContext _dbContext; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public AccountRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// AddAccountAsync
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task<int> AddAccountAsync(Account account)
        {
            await _dbContext.Accounts.AddAsync(account);
            await _dbContext.SaveChangesAsync();
            return account.Id;
        }

        /// <summary>
        /// GetAccountByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Account> GetAccountByIdAsync(int id)
        {
            return await _dbContext.Accounts.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// UpdateAccountAsync
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task<int> UpdateAccountAsync(Account account)
        {
            _dbContext.Accounts.Update(account);
            await _dbContext.SaveChangesAsync();
            return account.Id;
        }

        /// <summary>
        /// CheckCustomerWithSameAccountTypeExists
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <param name="AccountType"></param>
        /// <returns></returns>
        public bool CheckCustomerWithSameAccountTypeExists(int CustomerId, AccountType AccountType)
        {
            bool retVal = true;
            var retval = _dbContext.Customers.Where(x => x.Id == CustomerId).FirstOrDefault();
            if (retval == null)
            {
                return false;
            }

            var returnData = _dbContext.Accounts.Where(x => x.CustomerId == CustomerId && x.AccountType == AccountType).FirstOrDefault();
            if (returnData != null)
            {
                return false;
            }

            return retVal;
        }

    }
}
