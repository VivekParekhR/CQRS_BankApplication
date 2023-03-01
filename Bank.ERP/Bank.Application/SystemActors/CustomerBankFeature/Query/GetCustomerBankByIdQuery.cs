#region Using
using Bank.Core.Entity;
using Bank.Core.ViewModel;
using MediatR; 
#endregion

namespace Bank.Application.SystemActors.AccountFeature.Query
{
    public class GetCustomerBankByIdQuery : IRequest<List<CustomerBankViewModel>>
    {
        public int CustomerId { get; set; } 

    }
}
