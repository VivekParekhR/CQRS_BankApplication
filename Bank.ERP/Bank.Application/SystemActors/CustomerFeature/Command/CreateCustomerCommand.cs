#region Using
using MediatR; 
#endregion

namespace Bank.Application.SystemActors.CustomerFeature.Command
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int BankId { get; set; }
    }
}
