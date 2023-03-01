#region Using
using Bank.Core.Repository;
using Bank.XunitTest.Test.Infrstructure;
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

            context.Banks.Add(new Core.Entity.Bank { Id = 3, Name = "Kotak", BranchId = 1,CreatedById=1,CreatedDate=System.DateTime.Now});
            context.SaveChanges();

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
            var result = context.Banks.Single(a => a.Name == "HDFC");

            result.Name.ShouldBe("HDFC");
        }

        [Fact(DisplayName = "Bank Exists Negative Test")]
        public async Task Bank_ExistsNegativeTest()
        {
            var context = BankUnitTestContext.Get();
            BankRepository ObjbankRepository = new BankRepository(context);


            // Assert
            var branchOne = context.Banks.Single(a => a.Name == "Union");

            branchOne.Name.ShouldBe("Union");
        }

    }
}
