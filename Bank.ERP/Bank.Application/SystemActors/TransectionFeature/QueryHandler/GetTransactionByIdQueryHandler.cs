#region Using
using Bank.Application.SystemActors.TransectionFeature.Query;
using Bank.Core.Entity;
using Bank.Core.Interface;
using MediatR; 
#endregion

namespace Bank.Application.SystemActors.TransectionFeature.QueryHandler
{
    public class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, Transaction>
    {
        #region Property
        private readonly ITransactionRepository _repository; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public GetTransactionByIdQueryHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handle GetTransactionByIdQueryHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Transaction> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetTransactionByIdAsync(request.Id);
        }
    }
}
