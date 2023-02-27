using Bank.Application.SystemActors.BranchFeature.CommandHandler;
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
    [Collection("Branch Test")]
    public class BranchTest
    {
        [Fact(DisplayName = "Branch AddTest")]
        public async Task Branch_Addtest()
        {
            var context = BankUnitTestContext.Get();
            BankRepository ObjbankRepository = new BankRepository(context);

            context.Branches.Add(new Core.Entity.Branch { Name = "branchOne", Id = 3 });
            context.SaveChanges();

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
            var branchOne = context.Branches.Single(a => a.Name == "PeopleFirstBranch");

            branchOne.Name.ShouldBe("PeopleFirstBranch");
        }

        [Fact(DisplayName = "Branch Exists Negative Test")]
        public async Task Branch_ExistsNegativeTest()
        {
            var context = BankUnitTestContext.Get();
            BankRepository ObjbankRepository = new BankRepository(context);


            // Assert
            var branchOne = context.Branches.Single(a => a.Name == "POBranch");

            branchOne.Name.ShouldBe("POBranch");
        }

    }
}
