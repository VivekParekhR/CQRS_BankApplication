using Bank.Domain.Entity; 
using Bank.Domain.Enum;
using Bank.Domain.Interface;

namespace Bank.Domain.Interface
{
    public interface ICustomerBankRepository : IGenericRepository<CustomerBank>
    { 
        Task<CustomerBank> GetCustomerBankByBankIdAndCustomerIdAsync(int customerId);
        Task<string> GetCustomerBankByCustomerIdAsync(int customerId); // to do view model
        bool CheckCustomerWithSameAccountTypeExists(int CustomerId, AccountType AccountType,int bankId);
    }
}
