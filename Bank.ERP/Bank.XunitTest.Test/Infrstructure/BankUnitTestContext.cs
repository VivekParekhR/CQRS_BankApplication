#region Using
using Bank.Domain.Entity;
using Bank.Domain.Enum;
using Bank.Infrastructure.Persistence;
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
                new Branch {Id = 1, Name = "PeopleFirstBranch",BranchCode="Test", CreatedDate=System.DateTime.Now,CreatedById=1, },
                new Branch {Id = 2, Name = "CompanyFirstBranch" ,BranchCode="Test", CreatedDate=System.DateTime.Now,CreatedById=1}
            };
            context.Branches.AddRange(branches);



            var bankes = new[]
            {
                new Domain.Entity.Bank {Id = 1, Name = "HDFC",BranchId=1 ,CreatedById=1,CreatedDate=System.DateTime.Now },
                new Domain.Entity.Bank {Id = 2, Name = "ICICI", BranchId=2 ,CreatedById=1,CreatedDate=System.DateTime.Now}
            };
            context.Banks.AddRange(bankes);




            var customers = new[]
            {
                new Customer {Id = 1, FirstName = "Sam", Email="sam@gmail.com",LastName="Sam",CreatedDate=System.DateTime.Now,CreatedById=1,IsDeleted=false,PhoneNo="6658987545"},
                new Customer {Id = 2, FirstName = "Peater",Email="peater@gmail.com" ,LastName="Peater",CreatedDate=System.DateTime.Now,CreatedById=1,IsDeleted=false,PhoneNo="6658987545"}
            };
            context.Customers.AddRange(customers);




            var accounts = new[]
            {
                new CustomerBank {Id = 1, Balance = 1000, AccountNumber="123",CustomerId=1, AccountType= AccountType.Savings,BankId=1,CreatedById=1,IsDeleted=false,CreatedDate=System.DateTime.Now},
                new CustomerBank {Id = 2, Balance = 1500, AccountNumber="24656",CustomerId=2, AccountType= AccountType.Current,BankId=1,CreatedById=1,IsDeleted=false,CreatedDate=System.DateTime.Now}
            }; 
            context.CustomerBanks.AddRange(accounts);




            var transection = new[]
            {
                new Transaction {Id = 1, Amount = 100,BankId=1,CustomerId=2,TransactionId=Guid.NewGuid(),TransactionType=TransactionType.Withdrawal,TransectionDate=System.DateTime.Now,TransectionRemarks="Remarks"},
                new Transaction {Id = 2, Amount = 200,BankId=2,CustomerId=3,TransactionId=Guid.NewGuid(),TransactionType=TransactionType.Deposite,TransectionDate=System.DateTime.Now,TransectionRemarks="Remarks"}
            };
            context.Transactions.AddRange(transection);


            context.SaveChanges();
            return context;
        }
    }
}
