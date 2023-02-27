using Bank.Core.Entity;
using Bank.Infrastructure.Enum;

namespace Bank.Core.Interface
{
    public interface IAccountRepository
    {
        Task<int> AddAccountAsync(Account account);
        Task<int> UpdateAccountAsync(Account account);
        Task<Account> GetAccountByIdAsync(int id);
        bool CheckCustomerWithSameAccountTypeExists(int CustomerId, AccountType AccountType);
    }
}
