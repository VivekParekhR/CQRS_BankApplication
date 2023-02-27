#region Using
using Bank.Infrastructure.Enum;
using MediatR; 
#endregion

namespace Bank.Application.SystemActors.AccountFeature.Command
{
    public class CreateAccountCommand : IRequest<int>
    {
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }
        public AccountType AccountType { get; set; }
    }
}
