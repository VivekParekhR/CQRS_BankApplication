#region Using
using Bank.Core.ViewModel;
using MediatR;

#endregion
namespace Bank.Core.Modules.TransectionFeature.GetTransactionHistoryByAccountNumber
{
    public class GetTransactionHistoryByAccountNumberQuery : IRequest<TransactionHistoryViewModel>
    {
        public int BankId { get; set; }
        public int CustomerId { get; set; }

    }
}
