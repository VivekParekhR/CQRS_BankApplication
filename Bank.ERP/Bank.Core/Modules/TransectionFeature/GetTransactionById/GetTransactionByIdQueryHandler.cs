#region Using
using Bank.Domain.Entity;
using Bank.Domain.Interface;
using MediatR;
#endregion

namespace Bank.Core.Modules.TransectionFeature.GetTransactionById
{
    public class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, Transaction>
    {
        #region Property
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        public GetTransactionByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }

        /// <summary>
        /// Handle GetTransactionByIdQueryHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Transaction> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.TransactionService.GetById(request.Id); 
        }
    }
}
