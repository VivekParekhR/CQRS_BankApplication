namespace Bank.Core.Interface
{
    public interface IBankRepository
    {
        Task<int> AddBankAsync(Domain.Entity.Bank bank);  
        Task<Domain.Entity.Bank> GetBankByIdAsync(int id);    
        bool CheckBankExists(string bankName,int branchId);  
    }
}
