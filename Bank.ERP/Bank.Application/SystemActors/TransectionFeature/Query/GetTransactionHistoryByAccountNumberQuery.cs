#region Using
using Bank.Core.ViewModel;
using MediatR;

#endregion
namespace Bank.Application.SystemActors.TransectionFeature.Query
{
    public class GetTransactionHistoryByAccountNumberQuery : IRequest<TransactionHistoryViewModel>
    {
        public int BankId { get; set; }
        public int CustomerId { get; set; }

    }
}
