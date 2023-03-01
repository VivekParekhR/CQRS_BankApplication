#region Using
using Bank.Application.SystemActors.AccountFeature.Query;
using Bank.Core.Entity;
using Bank.Core.Interface;
using Bank.Core.ViewModel;
using MediatR;

#endregion
namespace Bank.Application.SystemActors.AccountFeature.QueryHandler
{
    public class GetCustomerBankByIdQueryHandler : IRequestHandler<GetCustomerBankByIdQuery,  List<CustomerBankViewModel>>
    {
        #region Property
        private readonly ICustomerBankRepository _repository; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public GetCustomerBankByIdQueryHandler(ICustomerBankRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handle GetAccountByIdQueryHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<CustomerBankViewModel>> Handle(GetCustomerBankByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCustomerBankByCustomerIdAsync(request.CustomerId);
        }
    }
}
