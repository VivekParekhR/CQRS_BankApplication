#region Using
using Bank.Core.Context;
using Bank.Core.Interface;
using Microsoft.EntityFrameworkCore;

#endregion
namespace Bank.Core.Repository
{
    public class BranchRepository : IBranchRepository
    {
        #region Property
        private readonly BankDbContext _dbContext; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public BranchRepository(BankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// AddBranchAsync
        /// </summary>
        /// <param name="branch"></param>
        /// <returns></returns>
        public async Task<int> AddBranchAsync(Entity.Branch branch)
        {
            await _dbContext.Branches.AddAsync(branch);
            await _dbContext.SaveChangesAsync();
            return branch.Id;
        }

        /// <summary>
        /// GetBranchByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Entity.Branch> GetBranchByIdAsync(int id)
        {
            return await _dbContext.Branches
                                   .Include(x => x.Banks)
                                   .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// CheckBranchExists
        /// </summary>
        /// <param name="branchName"></param>
        /// <returns></returns>
        public bool CheckBranchExists(string branchName)
        {
            bool retVal = true;
            var retval = _dbContext.Branches.Where(x => x.Name == branchName).FirstOrDefault();
            if (retval != null)
            {
                retVal = false;
            }
            return retVal;
        }
    }
}
