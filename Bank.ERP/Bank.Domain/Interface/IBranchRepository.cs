#region Using
using Bank.Domain.Entity;
using Bank.Domain.Interface;
#endregion

namespace Bank.Core.Interface
{
    public interface IBranchRepository : IGenericRepository<Branch>
    { 
        bool CheckBranchExists(string branchName);
    }
}
