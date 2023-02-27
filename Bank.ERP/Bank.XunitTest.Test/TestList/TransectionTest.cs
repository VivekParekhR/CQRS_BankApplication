using Bank.Core.Entity;
using Bank.Core.Repository;
using Bank.XunitTest.Test.Infrstructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.XunitTest.Test.TestList
{
    [Collection("Transection Test")]
    public class TransectionTest
    {
        [Fact(DisplayName = "Transection AddTest Negative")]
        public async Task Transection_Addtest()
        {
            var context = BankUnitTestContext.Get();
            BankRepository ObjbankRepository = new BankRepository(context);

            decimal retData = context.Accounts.Where(x => x.Id == 2).Select(x => x.Balance).SingleOrDefault();
            var retDataTwo = context.Accounts.Where(x => x.Id == 1).Select(x => x.Balance).SingleOrDefault();

            if (retData > retDataTwo)
            {
                context.Transactions.Add(new Transaction { Id = 5, Amount = 5000, BankId = 1, FromAccountId = 1, ToAccountId = 2, TransactionId = Guid.NewGuid() });
                context.SaveChanges();
            }
             
            decimal getretData = context.Accounts.Where(x => x.Id == 1).Select(x => x.Balance).SingleOrDefault();
            getretData.ShouldBeGreaterThan(100);
        }

        [Fact(DisplayName = "Transection Add Negative Test")]
        public async Task Transection_AddPositivetest()
        {
            var context = BankUnitTestContext.Get();
            BankRepository ObjbankRepository = new BankRepository(context);

            decimal retData = context.Accounts.Where(x => x.Id == 1).Select(x => x.Balance).SingleOrDefault();
            var retDataTwo = context.Accounts.Where(x => x.Id == 2).Select(x => x.Balance).SingleOrDefault();

            if (retData > retDataTwo)
            {
                context.Transactions.Add(new Transaction { Id = 5, Amount = 5000, BankId = 1, FromAccountId = 1, ToAccountId = 2, TransactionId = Guid.NewGuid() });
                context.SaveChanges();
            }


            decimal getretData = context.Accounts.Where(x => x.Id == 1).Select(x => x.Balance).SingleOrDefault();
            getretData.ShouldBeGreaterThan(4000);  
        }
    }
}
