using Bank.Core.Entity;
using Bank.Core.ViewModel;
using Bank.Infrastructure.Enum;

namespace Bank.Core.Interface
{
    public interface ICustomerBankRepository
    {
        Task<int> AddCustomerBankAsync(CustomerBank account);
        Task<int> UpdateCustomerBankAsync(CustomerBank account);
        Task<CustomerBank> GetCustomerBankByIdAsync(int id);
        Task<CustomerBank> GetCustomerBankByBankIdAndCustomerIdAsync(int customerId);
        Task<List<CustomerBankViewModel>> GetCustomerBankByCustomerIdAsync(int customerId);
        bool CheckCustomerWithSameAccountTypeExists(int CustomerId, AccountType AccountType,int bankId);
    }
}
