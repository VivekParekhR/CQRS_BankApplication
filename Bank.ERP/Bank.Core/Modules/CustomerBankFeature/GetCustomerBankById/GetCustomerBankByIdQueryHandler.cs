#region Using
using Bank.Core.ViewModel;
using Bank.Domain.Interface;
using MediatR;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

#endregion
namespace Bank.Core.Modules.CustomerBankFeature.GetCustomerBankById
{
    public class GetCustomerBankByIdQueryHandler : IRequestHandler<GetCustomerBankByIdQuery, List<CustomerBankViewModel>>
    {
        #region Property
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        public GetCustomerBankByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }

        /// <summary>
        /// Handle GetAccountByIdQueryHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<CustomerBankViewModel>> Handle(GetCustomerBankByIdQuery request, CancellationToken cancellationToken)
        {
            var retVal = await _unitOfWork.CustomerBankService.GetCustomerBankByCustomerIdAsync(request.CustomerId); 
            return  JsonConvert.DeserializeObject<List<CustomerBankViewModel>>(retVal);
        }
    }
}
