#region Using
using MediatR; 
#endregion

namespace Bank.Application.SystemActors.TransectionFeature.Command
{
    public class TransferCommand : IRequest<int>
    {
        public int SourceAccountId { get; set; }
        public int DestinationAccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
