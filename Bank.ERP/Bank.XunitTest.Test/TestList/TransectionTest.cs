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

            decimal retData = context.CustomerBanks.Where(x => x.Id == 2).Select(x => x.Balance).SingleOrDefault();
            var retDataTwo = context.CustomerBanks.Where(x => x.Id == 1).Select(x => x.Balance).SingleOrDefault();

            if (retData > retDataTwo)
            {
                context.Transactions.Add(new Transaction {Id = 5, Amount = 5000, BankId = 1, CustomerId = 2, TransactionId = Guid.NewGuid(),TransactionType=Infrastructure.Enum.TransactionType.Deposite,TransectionDate=System.DateTime.Now,TransectionRemarks="Test" });
                context.SaveChanges();
            }
             
            decimal getretData = context.CustomerBanks.Where(x => x.Id == 1).Select(x => x.Balance).SingleOrDefault();
            getretData.ShouldBeGreaterThan(100);
        }

        [Fact(DisplayName = "Transection Add Negative Test")]
        public async Task Transection_AddPositivetest()
        {
            var context = BankUnitTestContext.Get();
            BankRepository ObjbankRepository = new BankRepository(context);

            decimal retData = context.CustomerBanks.Where(x => x.Id == 1).Select(x => x.Balance).SingleOrDefault();
            var retDataTwo = context.CustomerBanks.Where(x => x.Id == 2).Select(x => x.Balance).SingleOrDefault();

            if (retData > retDataTwo)
            {
                context.Transactions.Add(new Transaction { Id = 5, Amount = 5000, BankId = 1, CustomerId = 1, TransactionId = Guid.NewGuid(), TransactionType = Infrastructure.Enum.TransactionType.Withdrawal, TransectionDate = System.DateTime.Now, TransectionRemarks = "Test" });
                context.SaveChanges();
            }


            decimal getretData = context.CustomerBanks.Where(x => x.Id == 1).Select(x => x.Balance).SingleOrDefault();
            getretData.ShouldBeGreaterThan(4000);  
        }
    }
}
