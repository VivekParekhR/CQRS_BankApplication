#region Using
using Bank.Core.Context;
using Bank.Core.Entity;
using Bank.Core.Interface;
using Bank.Core.ViewModel;
using Bank.Infrastructure.Enum;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
#endregion
namespace Bank.Core.Repository
{
    public class CustomerBankRepository : ICustomerBankRepository
    {
        #region Property
        private readonly BankDbContext _dbContext; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public CustomerBankRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// AddAccountAsync
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task<int> AddCustomerBankAsync(CustomerBank account)
        {
            await _dbContext.CustomerBanks.AddAsync(account);
            await _dbContext.SaveChangesAsync();
            return account.Id;
        }

        /// <summary>
        /// GetAccountByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CustomerBank> GetCustomerBankByIdAsync(int id)
        {
            return await _dbContext.CustomerBanks.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// GetCustomerBankByBankIdAndCustomerIdAsync
        /// </summary>
        /// <param name="bankId"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<CustomerBank> GetCustomerBankByBankIdAndCustomerIdAsync(int customerId)
        { 
            return await _dbContext.CustomerBanks.Where(x=>x.CustomerId == customerId).FirstOrDefaultAsync();

        }

        public async Task<List<CustomerBankViewModel>> GetCustomerBankByCustomerIdAsync(int customerId) {

            var customerBank = _dbContext.CustomerBanks;
            var bank = _dbContext.Banks;

            var returnValue = (from e in customerBank
                               join o in bank on e.BankId equals o.Id
                               select new CustomerBankViewModel
                               {
                                    AccountNumber = e.AccountNumber,
                                    AccountType = Convert.ToString((AccountType)e.AccountType),
                                    Balance=e.Balance,
                                    BankId = e.BankId,  
                                    BankName=o.Name,
                                    CustomerId = e.CustomerId,
                                    CreatedDate=e.CreatedDate,
                                    CreatedById=e.CreatedById,  
                                    Id=e.Id,
                                    UpdatedById=e.UpdatedById,
                                    UpdatedDate=e.UpdatedDate
                               });


            var retVal = await returnValue.Where(x=>x.CustomerId==customerId).ToListAsync();

            return retVal;
        }

        /// <summary>
        /// UpdateAccountAsync
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task<int> UpdateCustomerBankAsync(CustomerBank account)
        {
            _dbContext.CustomerBanks.Update(account);
            await _dbContext.SaveChangesAsync();
            return account.Id;
        }

        /// <summary>
        /// CheckCustomerWithSameAccountTypeExists
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <param name="AccountType"></param>
        /// <param name="bankId"></param>
        /// <returns></returns>
        public bool CheckCustomerWithSameAccountTypeExists(int CustomerId, AccountType AccountType,int bankId)
        {
            bool retVal = true; 
            var returnData = _dbContext.CustomerBanks.Where(x => x.CustomerId == CustomerId && x.BankId== bankId && x.AccountType == AccountType).FirstOrDefault();
            if (returnData != null)
            {
                return false;
            }

            return retVal;
        }

    }
}
