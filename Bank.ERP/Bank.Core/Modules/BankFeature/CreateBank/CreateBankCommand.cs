#region Using
using MediatR;
#endregion

namespace Bank.Core.Modules.BankFeature.CreateBank
{
    public class CreateBankCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public int BranchId { get; set; }
    }
}
