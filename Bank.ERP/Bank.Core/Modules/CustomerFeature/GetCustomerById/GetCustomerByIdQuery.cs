#region Using 
using Bank.Domain.Entity;
using MediatR;
#endregion

namespace Bank.Core.Modules.CustomerFeature.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public int Id { get; set; }
    }
}
