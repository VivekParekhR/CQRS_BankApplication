using Bank.Domain.Entity;
using Bank.Domain.Interface;

namespace Bank.Core.Interface
{
    public interface IBankRepository : IGenericRepository<Domain.Entity.Bank>
    {
        Task<int> AddBankAsync(Domain.Entity.Bank bank);  
        Task<Domain.Entity.Bank> GetBankByIdAsync(int id);    
        bool CheckBankExists(string bankName,int branchId);  
    }
}
