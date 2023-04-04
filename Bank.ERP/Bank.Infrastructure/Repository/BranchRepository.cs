#region Using
using Bank.Core.Interface;
using Bank.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Bank.Domain.Entity;

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
        /// AddBranchAsync
        /// </summary>
        /// <param name="branch"></param>
        /// <returns></returns>
        public async Task<int> AddBranchAsync(Branch branch)
        {
            await Add(branch);
            await _dbContext.SaveChangesAsync();
            return branch.Id;
        }

        /// <summary>
        /// GetBranchByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Branch> GetBranchByIdAsync(int id)
        {
            return await GetById(id);
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
