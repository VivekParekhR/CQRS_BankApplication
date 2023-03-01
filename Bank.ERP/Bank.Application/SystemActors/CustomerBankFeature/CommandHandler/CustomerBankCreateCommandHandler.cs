#region Using
using Bank.Application.SystemActors.AccountFeature.Command;
using Bank.Core.Entity;
using Bank.Core.Interface;
using Bank.Infrastructure.Enum;
using MediatR; 
#endregion

namespace Bank.Application.SystemActors.AccountFeature.CommandHandler
{
    public class CustomerBankCreateCommandHandler : IRequestHandler<CustomerBankCreateCommand, int>
    {
        #region Property
        private readonly ICustomerBankRepository _repository; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public CustomerBankCreateCommandHandler(ICustomerBankRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handle CreateAccountCommandHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(CustomerBankCreateCommand request, CancellationToken cancellationToken)
        {
            var account = new CustomerBank
            {
                AccountNumber = request.AccountNumber,
                Balance = request.Balance,
                CustomerId = request.CustomerId,
                AccountType = request.AccountType,
                BankId = request.BankId,    
                CreatedById = Convert.ToInt32(SystemUser.Admin),
                CreatedDate = System.DateTime.Now
            };

            await _repository.AddCustomerBankAsync(account);
            return account.Id;
        }
    }
}
