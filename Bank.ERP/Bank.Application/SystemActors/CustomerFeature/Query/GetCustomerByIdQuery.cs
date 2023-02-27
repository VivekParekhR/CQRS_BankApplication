#region Using
using Bank.Core.Entity;
using MediatR; 
#endregion

namespace Bank.Application.SystemActors.CustomerFeature.Query
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public int Id { get; set; }
    }
}
