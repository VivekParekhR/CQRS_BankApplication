#region Using
using MediatR; 
#endregion

namespace Bank.Application.SystemActors.BankFeature.Command
{
    public class CreateBankCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string IFSCCode { get; set; }
        public int BranchId { get; set; }
    }
}
