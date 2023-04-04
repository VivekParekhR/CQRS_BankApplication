#region Using
using Bank.Core.Interface;
using Bank.Domain.Entity;
using Bank.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

#endregion
namespace Bank.Infrastructure.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        #region Property

        private readonly BankDbContext _dbContext;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public CustomerRepository(BankDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="PhoneNo"></param>
        /// <returns></returns>
        public bool CheckEmailWithPhoneExists(string email, string PhoneNo) {
            bool retVal = true;
            var retval = Find(x => x.Email == email && x.PhoneNo == PhoneNo).FirstOrDefault();
            if (retval != null)
            {
                retVal = false;
            }
            return retVal;
        }
    }
}
