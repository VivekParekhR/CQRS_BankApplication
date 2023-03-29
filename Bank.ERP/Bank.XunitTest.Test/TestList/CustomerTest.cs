using Bank.Domain.Entity;
using Bank.Infrastructure.Repository;
using Bank.XunitTest.Test.Infrstructure;
using Microsoft.EntityFrameworkCore;
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

            context.Customers.Add(new Customer { Id = 1, FirstName = "Sam",  Email = "sam@gmail.com",LastName="sam",CreatedDate=System.DateTime.Now,CreatedById=1,IsDeleted=false,PhoneNo="65879546" });
            await context.SaveChangesAsync();

            // Assert
            var result = context.Customers.Single(a => a.FirstName == "Sam");

            result.FirstName.ShouldContain("Kot");
        }

        [Fact(DisplayName = "Customer Exists Test")]
        public async Task Customer_Exists()
        {
            var context = BankUnitTestContext.Get();
            BankRepository ObjbankRepository = new BankRepository(context);


            // Assert
            var result = await context.Customers.SingleAsync(a => a.FirstName == "Sam");

            result.FirstName.ShouldBe("Sam");
        }

        [Fact(DisplayName = "Customer Belomngs From Perticular Bank Test")]
        public async Task Customer_BelomngsFromPerticularBankTest()
        {
            var context = BankUnitTestContext.Get();
            BankRepository ObjbankRepository = new BankRepository(context);


            // Assert
            var result = await context.Customers.SingleAsync(a => a.CreatedById == 2);

            result.FirstName.ShouldBe("Peater");
        }
    }
}
