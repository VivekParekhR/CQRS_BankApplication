#region Using
using Bank.Application.SystemActors.AccountFeature.Command;
using Bank.Core.Entity;
using Bank.Core.Interface;
using MediatR; 
#endregion

namespace Bank.Application.SystemActors.AccountFeature.CommandHandler
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, int>
    {
        #region Property
        private readonly IAccountRepository _repository; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public CreateAccountCommandHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handle CreateAccountCommandHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new Account
            {
                AccountNumber = Guid.NewGuid(),
                Balance = request.Balance,
                CustomerId = request.CustomerId,
                AccountType = request.AccountType
            };

            await _repository.AddAccountAsync(account);
            return account.Id;
        }
    }
}
