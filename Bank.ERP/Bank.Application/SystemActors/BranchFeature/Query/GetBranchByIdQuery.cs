#region MyRegion
using MediatR;

#endregion

namespace Bank.Application.SystemActors.BranchFeature.Query
{
    public class GetBranchByIdQuery : IRequest<Bank.Core.Entity.Branch>
    {
        public int Id { get; set; }
    }
}
