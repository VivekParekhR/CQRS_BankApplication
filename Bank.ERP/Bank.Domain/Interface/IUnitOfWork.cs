 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Interface
{
    public interface IUnitOfWork
    {
        IBankRepository BankService { get; }
        IBranchRepository BranchService { get; }
        ICustomerRepository CustomerService { get; }
        ICustomerBankRepository CustomerBankService { get; }
        ITransactionRepository TransactionService { get; }
        Task<int> Complete();
    }
}
