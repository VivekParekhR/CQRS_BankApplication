#region Using
using Bank.Application.SystemActors.TransectionHistoryFeature.Query;
using Bank.Core.Interface;
using Bank.Core.ViewModel;
using MediatR; 
#endregion

namespace Bank.Application.TransectionHistoryFeature.QueryHandler
{
    public class GetTransactionHistoryByAccountIdQueryHandler : IRequestHandler<GetTransactionHistoryByAccountNumberQuery, TransactionHistoryViewModel>
    {
        #region Property
        private readonly ITransactionHistoryRepository _repository; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public GetTransactionHistoryByAccountIdQueryHandler(ITransactionHistoryRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handle GetTransactionHistoryByAccountIdQueryHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TransactionHistoryViewModel> Handle(GetTransactionHistoryByAccountNumberQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetTransactionHistoryByAccountIdAsync(request.AccountNumber);
        }
    }
}
