#region Using
using Bank.Domain.Entity;
using Bank.Domain.Interface;
using Bank.Infrastructure.Persistence;
#endregion
namespace Bank.Infrastructure.Repository
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        #region Property
        private readonly BankDbContext _dbContext; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public BranchRepository(BankDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
         
        /// <summary>
        /// CheckBranchExists
        /// </summary>
        /// <param name="branchName"></param>
        /// <returns></returns>
        public bool CheckBranchExists(string branchName)
        {
            bool retVal = true;
            var retval = Find(x => x.Name == branchName).FirstOrDefault();
            if (retval != null)
            {
                retVal = false;
            }
            return retVal;
        }
    }
}
