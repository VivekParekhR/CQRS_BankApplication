#region Using
using Bank.Core.Entity; 
#endregion

namespace Bank.Core.Interface
{
    public interface IBranchRepository
    {
        Task<int> AddBranchAsync(Branch branch);
        Task<Branch> GetBranchByIdAsync(int id);
        bool CheckBranchExists(string branchName);
    }
}
