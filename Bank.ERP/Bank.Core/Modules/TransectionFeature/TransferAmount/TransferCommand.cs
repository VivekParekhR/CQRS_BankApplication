#region Using
using Bank.Domain.Enum;
using MediatR;

#endregion

namespace Bank.Core.Modules.TransectionFeature.TransferAmount
{
    public class TransferCommand : IRequest<int>
    {
        public int BankId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public string TransectionRemarks { get; set; } = string.Empty;

    }
}
