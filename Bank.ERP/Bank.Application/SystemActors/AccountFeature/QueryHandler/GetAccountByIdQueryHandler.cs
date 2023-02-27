#region Using
using Bank.Application.SystemActors.AccountFeature.Query;
using Bank.Core.Entity;
using Bank.Core.Interface;
using MediatR;

#endregion
namespace Bank.Application.SystemActors.AccountFeature.QueryHandler
{
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery,  Account>
    {
        #region Property
        private readonly IAccountRepository _repository; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public GetAccountByIdQueryHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handle GetAccountByIdQueryHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Account> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAccountByIdAsync(request.Id);
        }
    }
}
