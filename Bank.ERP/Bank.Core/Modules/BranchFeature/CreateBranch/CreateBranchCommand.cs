#region Using
using MediatR;
#endregion

namespace Bank.Core.Modules.BranchFeature.CreateBranch
{
    public class CreateBranchCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string BranchCode { get; set; } = string.Empty;
    }
}
