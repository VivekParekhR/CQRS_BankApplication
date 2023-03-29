#region MyRegion
using MediatR;

#endregion

namespace Bank.Core.Modules.BranchFeature.GetBranchById
{
    public class GetBranchByIdQuery : IRequest<Domain.Entity.Branch>
    {
        public int Id { get; set; }
    }
}
