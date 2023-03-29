#region Using
using Bank.Domain.Entity; 
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
