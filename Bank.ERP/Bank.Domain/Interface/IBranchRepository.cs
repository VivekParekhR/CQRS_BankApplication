#region Using
using Bank.Domain.Entity;
using Bank.Domain.Interface;
#endregion

namespace Bank.Core.Interface
{
    public interface IBranchRepository : IGenericRepository<Branch>
    {
        Task<int> AddBranchAsync(Branch branch);
        Task<Branch> GetBranchByIdAsync(int id);
        bool CheckBranchExists(string branchName);
    }
}
