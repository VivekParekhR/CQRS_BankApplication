#region Using
using Bank.Application.SystemActors.BankFeature.Query;
using Bank.Core.Interface;
using MediatR; 
#endregion

namespace Bank.Application.SystemActors.BankFeature.QueryHandler
{
    public class GetBankByIdQueryHandler : IRequestHandler<GetBankByIdQuery, Bank.Core.Entity.Bank>
    {
        #region Property
        private readonly IBankRepository _repository; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public GetBankByIdQueryHandler(IBankRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handle GetBankByIdQueryHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Bank.Core.Entity.Bank> Handle(GetBankByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetBankByIdAsync(request.Id);
        }
    }
}
