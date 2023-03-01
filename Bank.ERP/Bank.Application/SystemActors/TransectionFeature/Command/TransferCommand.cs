#region Using
using Bank.Infrastructure.Enum;
using MediatR;

#endregion

namespace Bank.Application.SystemActors.TransectionFeature.Command
{
    public class TransferCommand : IRequest<int>
    {
        public int BankId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public string TransectionRemarks { get; set; }

    }
}
