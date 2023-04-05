#region Using
using Bank.Core.ViewModel;
using Bank.Domain.Interface;
using MediatR;
using Newtonsoft.Json;
#endregion

namespace Bank.Core.Modules.TransectionFeature.GetTransactionHistoryByAccountNumber
{
    public class GetTransactionHistoryByAccountIdQueryHandler : IRequestHandler<GetTransactionHistoryByAccountNumberQuery, TransactionHistoryViewModel>
    {
        #region Property
        private readonly IUnitOfWork _unitOfWork; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public GetTransactionHistoryByAccountIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }

        /// <summary>
        /// Handle GetTransactionHistoryByAccountIdQueryHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TransactionHistoryViewModel> Handle(GetTransactionHistoryByAccountNumberQuery request, CancellationToken cancellationToken)
        {
           var retVal = await _unitOfWork.TransactionService.GetTransactionHistoryByAccountIdAsync(request.BankId, request.CustomerId);
           return JsonConvert.DeserializeObject<TransactionHistoryViewModel>(retVal);
        }
    }
}
