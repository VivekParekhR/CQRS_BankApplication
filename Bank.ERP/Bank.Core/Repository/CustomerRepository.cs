﻿#region Using
using Bank.Core.Context;
using Bank.Core.Entity;
using Bank.Core.Interface;
using Microsoft.EntityFrameworkCore;

#endregion
namespace Bank.Core.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        #region Property

        private readonly BankDbContext _dbContext;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public CustomerRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// AddCustomerAsync
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<int> AddCustomerAsync(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return customer.Id;
        }


        /// <summary>
        /// GetCustomerByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _dbContext.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();
        }


        /// <summary>
        /// CheckEmailWithBankExists
        /// </summary>
        /// <param name="email"></param>
        /// <param name="bankId"></param>
        /// <returns></returns>
        public bool CheckEmailWithBankExists(string email, int bankId)
        {
            bool retVal = true;
            var retval = _dbContext.Customers.Where(x => x.Email == email && x.BankId == bankId).FirstOrDefault();
            if (retval != null)
            {
                retVal = false;
            }
            return retVal;
        }


        public async Task<int> GetBankByCustomerIdAsync(int customerId)
        {
            var bankId = await _dbContext.Customers.Where(c => c.Id == customerId).Select(x => x.BankId).FirstOrDefaultAsync();
            return bankId;

        }
    }
}
