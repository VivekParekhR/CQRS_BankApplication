#region Using 
using Bank.Core.ViewModel;
using MediatR;
#endregion

namespace Bank.Core.Modules.CustomerBankFeature.GetCustomerBankById
{
    public class GetCustomerBankByIdQuery : IRequest<List<CustomerBankViewModel>>
    {
        public int CustomerId { get; set; }

    }
}
