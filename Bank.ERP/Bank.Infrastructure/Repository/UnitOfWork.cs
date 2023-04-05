#region Using
using Bank.Core.Interface;
using Bank.Domain.Interface;
using Bank.Infrastructure.Persistence;

#endregion

namespace Bank.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BankDbContext _context;
        public IBankRepository BankService { get; private set; }
        public IBranchRepository BranchService { get; private set; }
        public ICustomerRepository CustomerService { get; private set; }
        public ICustomerBankRepository CustomerBankService { get; private set; }
        public ITransactionRepository TransactionService { get; private set; }

        public UnitOfWork(BankDbContext context)
        {
            _context = context;
            BankService = new BankRepository(_context);
            BranchService = new BranchRepository(_context);
            CustomerService = new CustomerRepository(_context);
            CustomerBankService = new CustomerBankRepository(_context);
            TransactionService = new TransactionRepository(_context);   
        }  
    
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
