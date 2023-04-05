using Bank.Domain.Entity;
using Bank.Domain.Interface;

namespace Bank.Domain.Interface
{
    public interface IBankRepository : IGenericRepository<Domain.Entity.Bank>
    {   
        bool CheckBankExists(string bankName,int branchId);  
    }
}
