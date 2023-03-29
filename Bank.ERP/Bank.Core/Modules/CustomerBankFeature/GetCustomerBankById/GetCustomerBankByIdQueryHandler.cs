#region Using
using Bank.Core.Interface;
using Bank.Core.ViewModel;
using MediatR;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

#endregion
namespace Bank.Core.Modules.CustomerBankFeature.GetCustomerBankById
{
    public class GetCustomerBankByIdQueryHandler : IRequestHandler<GetCustomerBankByIdQuery, List<CustomerBankViewModel>>
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
            var retVal = await _repository.GetCustomerBankByCustomerIdAsync(request.CustomerId);

            return JsonConvert.DeserializeObject<List<CustomerBankViewModel>>(retVal);
        }
    }
}
