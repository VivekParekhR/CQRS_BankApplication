#region Using
using Bank.Domain.Enum;
using MediatR;
#endregion

namespace Bank.Core.Modules.CustomerBankFeature.CustomerBankCreate
{
    public class CustomerBankCreateCommand : IRequest<int>
    {
        public int BankId { get; set; }
        public int CustomerId { get; set; }
        public string AccountNumber { get; set; } = string.Empty;   
        public AccountType AccountType { get; set; }
        public decimal Balance { get; set; }
    }
}
