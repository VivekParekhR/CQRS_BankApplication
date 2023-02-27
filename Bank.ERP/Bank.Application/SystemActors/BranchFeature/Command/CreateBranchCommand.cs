#region Using
using MediatR; 
#endregion

namespace Bank.Application.SystemActors.BranchFeature.Command
{
    public class CreateBranchCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
