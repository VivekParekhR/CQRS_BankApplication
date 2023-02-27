#region Using
using Bank.Application.SystemActors.TransectionFeature.Command;
using Bank.Core.Entity;
using Bank.Core.Interface;
using Bank.Core.Repository;
using Bank.Infrastructure.Exceptions;
using MediatR;

#endregion
namespace Bank.Application.SystemActors.TransectionFeature.CommandHandler
{
    public class TransferCommandHandler : IRequestHandler<TransferCommand, int>
    {
        #region Property
        private readonly IAccountRepository _accountRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionHistoryRepository _transactionHistoryRepository;


        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bankRepository"></param>
        public TransferCommandHandler(IAccountRepository accountRepository, ICustomerRepository customerRepository, ITransactionRepository transactionRepository, ITransactionHistoryRepository transactionHistoryRepository)
        {
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
            _transactionRepository = transactionRepository;
            _transactionHistoryRepository = transactionHistoryRepository;   
        }

        /// <summary>
        /// Handle TransferCommandHandler
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotExistsException"></exception>
        /// <exception cref="InsufficientFundsException"></exception>
        public async Task<int> Handle(TransferCommand command, CancellationToken cancellationToken)
        {
            var sourceAccount = await _accountRepository.GetAccountByIdAsync(command.SourceAccountId);
            var destinationAccount = await _accountRepository.GetAccountByIdAsync(command.DestinationAccountId);

            if (sourceAccount == null)
            {
                throw new EntityNotExistsException(typeof(Account).Name);
            }

            if (destinationAccount == null)
            {
                throw new EntityNotExistsException(typeof(Account).Name);
            }
            // Check if the source account has sufficient funds
            if (sourceAccount.Balance < command.Amount)
            {
                throw new InsufficientFundsException(sourceAccount.AccountNumber, sourceAccount.Balance);
            }

            // Update the account balances
            sourceAccount.Balance -= command.Amount;
            destinationAccount.Balance += command.Amount;

            await _accountRepository.UpdateAccountAsync(sourceAccount);
            await _accountRepository.UpdateAccountAsync(destinationAccount);

            var bankId = await _customerRepository.GetBankByCustomerIdAsync(sourceAccount.CustomerId);
            // Create transaction records
            var sourceTransaction = new Transaction
            {
                FromAccountId = sourceAccount.Id,
                ToAccountId = destinationAccount.Id,
                TransactionId = Guid.NewGuid(),
                Amount = -command.Amount,
                BankId = bankId
            };
            var tranId = await _transactionRepository.AddTransactionAsync(sourceTransaction);



            // Create transection history record 
            var sourceTransactionHistory = new TransactionHistory
            {
                AccountId = command.SourceAccountId,
                Date = DateTime.Now,
                Amount = -command.Amount
            };

            var destinationTransactionHistory = new TransactionHistory
            {
                AccountId = command.DestinationAccountId,
                Date = DateTime.Now,
                Amount = command.Amount
            };

            await _transactionHistoryRepository.AddTransactionHistoryAsync(sourceTransactionHistory);
            await _transactionHistoryRepository.AddTransactionHistoryAsync(destinationTransactionHistory);

            return tranId;
        }
    }
}
