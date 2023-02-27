#region Using
using Bank.Core.ViewModel;
using MediatR;

#endregion
namespace Bank.Application.SystemActors.TransectionHistoryFeature.Query
{
    public class GetTransactionHistoryByAccountNumberQuery : IRequest<TransactionHistoryViewModel>
    {
        public Guid AccountNumber { get; set; }
    }
}
