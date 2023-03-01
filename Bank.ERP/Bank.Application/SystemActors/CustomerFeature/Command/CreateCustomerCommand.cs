#region Using
using MediatR; 
#endregion

namespace Bank.Application.SystemActors.CustomerFeature.Command
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
    }
}
