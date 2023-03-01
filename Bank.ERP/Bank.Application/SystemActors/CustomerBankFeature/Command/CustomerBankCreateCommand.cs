#region Using
using Bank.Infrastructure.Enum;
using MediatR; 
#endregion

namespace Bank.Application.SystemActors.AccountFeature.Command
{
    public class CustomerBankCreateCommand : IRequest<int>
    {
        public int BankId { get; set; }
        public int CustomerId { get; set; }
        public string AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public decimal Balance { get; set; } 
    }
}
