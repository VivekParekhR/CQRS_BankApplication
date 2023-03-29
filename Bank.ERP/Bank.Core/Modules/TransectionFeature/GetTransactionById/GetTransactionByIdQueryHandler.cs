#region Using
using Bank.Core.Interface;
using Bank.Domain.Entity;
using MediatR;
#endregion

namespace Bank.Core.Modules.TransectionFeature.GetTransactionById
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
