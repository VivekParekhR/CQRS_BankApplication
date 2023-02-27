#region Using
using Bank.Core.Context;
using Bank.Core.Entity;
using Bank.Infrastructure.Enum;
using Microsoft.EntityFrameworkCore; 
#endregion

namespace Bank.XunitTest.Test.Infrstructure
{
    public class BankUnitTestContext
    {
        public static BankDbContext Get()
        {
            var options = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<BankDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new BankDbContext(options);



            var branches = new[]
            {
                new Branch {Id = 1, Name = "PeopleFirstBranch" },
                new Branch {Id = 2, Name = "CompanyFirstBranch"}
            };
            context.Branches.AddRange(branches);



            var bankes = new[]
            {
                new Core.Entity.Bank {Id = 1, Name = "HDFC",BranchId=1 , IFSCCode="HDFC0031"},
                new Core.Entity.Bank {Id = 2, Name = "ICICI", BranchId=2 , IFSCCode="ICICI09"}
            };
            context.Banks.AddRange(bankes);




            var customers = new[]
            {
                new Customer {Id = 1, Name = "Sam",BankId=1,Email="sam@gmail.com"},
                new Customer {Id = 2, Name = "Peater",BankId=2,Email="peater@gmail.com"}
            };
            context.Customers.AddRange(customers);




            var accounts = new[]
            {
                new Account {Id = 1, Balance = 1000, AccountNumber=Guid.NewGuid(),CustomerId=1, AccountType= AccountType.Savings},
                new Account {Id = 2, Balance = 1500, AccountNumber=Guid.NewGuid(),CustomerId=2, AccountType= AccountType.Salary}
            }; 
            context.Accounts.AddRange(accounts);




            var transection = new[]
            {
                new Transaction {Id = 1, Amount = 100,BankId=1,FromAccountId=1,ToAccountId=2,TransactionId=Guid.NewGuid()},
                new Transaction {Id = 2, Amount = 200,BankId=2,FromAccountId=2,ToAccountId=1,TransactionId=Guid.NewGuid()}
            };
            context.Transactions.AddRange(transection);


            context.SaveChanges();
            return context;
        }
    }
}
