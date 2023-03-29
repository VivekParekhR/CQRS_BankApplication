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
    [Collection("Branch Test")]
    public class BranchTest
    {
        [Fact(DisplayName = "Branch AddTest")]
        public async Task Branch_Addtest()
        {
            var context = BankUnitTestContext.Get();
            BankRepository ObjbankRepository = new BankRepository(context);

            context.Branches.Add(new Domain.Entity.Branch { Name = "branchOne", Id = 3,BranchCode="Test",CreatedById=1,CreatedDate=System.DateTime.Now });
            await context.SaveChangesAsync();

            // Assert
            var branchOne = context.Branches.Single(a => a.Name == "branchOne");

            branchOne.Name.ShouldContain("branchOne");
        }

        [Fact(DisplayName = "Branch Exists Test")]
        public async Task Branch_Exists()
        {
            var context = BankUnitTestContext.Get();
            BankRepository ObjbankRepository = new BankRepository(context);


            // Assert
            var branchOne =await context.Branches.SingleAsync(a => a.Name == "PeopleFirstBranch");

            branchOne.Name.ShouldBe("PeopleFirstBranch");
        }

        [Fact(DisplayName = "Branch Exists Negative Test")]
        public async Task Branch_ExistsNegativeTest()
        {
            var context = BankUnitTestContext.Get();
            BankRepository ObjbankRepository = new BankRepository(context);


            // Assert
            var branchOne = await context.Branches.SingleAsync(a => a.Name == "POBranch");

            branchOne.Name.ShouldBe("POBranch");
        }

    }
}
