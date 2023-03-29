#region Using
using Bank.Core.Interface;
using Bank.Core.ViewModel;
using MediatR;
using Newtonsoft.Json;
#endregion

namespace Bank.Core.Modules.TransectionFeature.GetTransactionHistoryByAccountNumber
{
    public class GetTransactionHistoryByAccountIdQueryHandler : IRequestHandler<GetTransactionHistoryByAccountNumberQuery, TransactionHistoryViewModel>
    {
        #region Property
        private readonly ITransactionRepository _repository;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public GetTransactionHistoryByAccountIdQueryHandler(ITransactionRepository repository)
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
            var retVal = await _repository.GetTransactionHistoryByAccountIdAsync(request.BankId, request.CustomerId);
            return JsonConvert.DeserializeObject<TransactionHistoryViewModel>(retVal);
        }
    }
}
