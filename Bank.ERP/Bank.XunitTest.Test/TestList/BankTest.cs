#region Using
using Bank.Infrastructure.Repository;
using Bank.XunitTest.Test.Infrstructure;
using Microsoft.EntityFrameworkCore;
using Shouldly;

#endregion
namespace Bank.XunitTest.Test.TestList
{
    [Collection("Bank Test")]
    public class BankTest
    { 
        [Fact(DisplayName = "Bank AddTest")]
        public async Task Bank_Addtest()
        {
            var context = BankUnitTestContext.Get();
            BankRepository ObjbankRepository = new BankRepository(context);

            context.Banks.Add(new Domain.Entity.Bank { Id = 3, Name = "Kotak", BranchId = 1,CreatedById=1,CreatedDate=System.DateTime.Now});
            await context.SaveChangesAsync();

            // Assert
            var result = context.Banks.Single(a => a.Name == "Kotak");

            result.Name.ShouldContain("Kot");
        }

        [Fact(DisplayName = "Bank Exists Test")]
        public async Task Bank_Exists()
        {
            var context = BankUnitTestContext.Get();
            BankRepository ObjbankRepository = new BankRepository(context);


            // Assert
            var result = await context.Banks.SingleAsync(a => a.Name == "HDFC");

            result.Name.ShouldBe("HDFC");
        }

        [Fact(DisplayName = "Bank Exists Negative Test")]
        public async Task Bank_ExistsNegativeTest()
        {
            var context = BankUnitTestContext.Get();
            BankRepository ObjbankRepository = new BankRepository(context);


            // Assert
            var branchOne = await context.Banks.SingleAsync(a => a.Name == "Union");

            branchOne.Name.ShouldBe("Union");
        }

    }
}
