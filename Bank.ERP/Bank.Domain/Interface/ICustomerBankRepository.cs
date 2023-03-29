using Bank.Domain.Entity; 
using Bank.Domain.Enum;

namespace Bank.Core.Interface
{
    public interface ICustomerBankRepository
    {
        Task<int> AddCustomerBankAsync(CustomerBank account);
        Task<int> UpdateCustomerBankAsync(CustomerBank account);
        Task<CustomerBank> GetCustomerBankByIdAsync(int id);
        Task<CustomerBank> GetCustomerBankByBankIdAndCustomerIdAsync(int customerId);
        Task<string> GetCustomerBankByCustomerIdAsync(int customerId); // to do view model
        bool CheckCustomerWithSameAccountTypeExists(int CustomerId, AccountType AccountType,int bankId);
    }
}
