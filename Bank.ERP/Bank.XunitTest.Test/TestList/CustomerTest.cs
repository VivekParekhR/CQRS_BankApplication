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
    [Collection("Customer Test")]
    public class CustomerTest
    {
        [Fact(DisplayName = "Customer AddTest")]
        public async Task Customer_Addtest()
        {
            var context = BankUnitTestContext.Get();
            BankRepository ObjbankRepository = new BankRepository(context);

            context.Customers.Add(new Customer { Id = 1, Name = "Sam", BankId = 1, Email = "sam@gmail.com" });
            context.SaveChanges();

            // Assert
            var result = context.Customers.Single(a => a.Name == "Sam");

            result.Name.ShouldContain("Kot");
        }

        [Fact(DisplayName = "Customer Exists Test")]
        public async Task Customer_Exists()
        {
            var context = BankUnitTestContext.Get();
            BankRepository ObjbankRepository = new BankRepository(context);


            // Assert
            var result = context.Customers.Single(a => a.Name == "Sam");

            result.Name.ShouldBe("Sam");
        }

        [Fact(DisplayName = "Customer Belomngs From Perticular Bank Test")]
        public async Task Customer_BelomngsFromPerticularBankTest()
        {
            var context = BankUnitTestContext.Get();
            BankRepository ObjbankRepository = new BankRepository(context);


            // Assert
            var result = context.Customers.Single(a => a.BankId == 2);

            result.Name.ShouldBe("Peater");
        }
    }
}
