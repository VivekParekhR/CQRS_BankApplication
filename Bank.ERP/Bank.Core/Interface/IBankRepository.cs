namespace Bank.Core.Interface
{
    public interface IBankRepository
    {
        Task<int> AddBankAsync(Entity.Bank bank);  
        Task<Entity.Bank> GetBankByIdAsync(int id);    
        bool CheckBankExists(string bankName,int branchId);  
    }
}
