#region Using
using Azure.Core;
using Bank.Core.Exceptions;
using Bank.Domain.Entity;
using Bank.Domain.Enum;
using Bank.Domain.Interface;
using MediatR;

#endregion
namespace Bank.Core.Modules.TransectionFeature.TransferAmount
{
    public class TransferCommandHandler : IRequestHandler<TransferCommand, int>
    {
        #region Property
        private readonly IUnitOfWork _unitOfWork; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bankRepository"></param>
        public TransferCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
            var CustomerBankObject = await _unitOfWork.CustomerBankService.GetCustomerBankByBankIdAndCustomerIdAsync(command.CustomerId);

            if (CustomerBankObject == null)
            {
                throw new EntityNotExistsException(typeof(CustomerBank).Name);
            }

            if (command.TransactionType == TransactionType.Withdrawal)
            {
                if (CustomerBankObject.Balance < command.Amount)
                {
                    throw new InsufficientFundsException(CustomerBankObject.AccountNumber, CustomerBankObject.Balance);
                }
            }

            var TransactionAdd = new Transaction
            {
                Amount = command.Amount,
                TransactionType = command.TransactionType,
                CustomerId = command.CustomerId,
                BankId = command.BankId,
                TransactionId = Guid.NewGuid(),
                TransectionDate = DateTime.Now,
                TransectionRemarks = command.TransectionRemarks
            };

            CustomerBankObject.Balance = command.TransactionType == TransactionType.Deposite ?
                                         CustomerBankObject.Balance + command.Amount :
                                             CustomerBankObject.Balance - command.Amount;


            Transaction.RaiseEvent(new Domain.Events.TransactionCreatedDomainEvent
            {
                Transaction = TransactionAdd,
                CustomerBank = CustomerBankObject
            });

            await _unitOfWork.TransactionService.Add(TransactionAdd);

            _unitOfWork.CustomerBankService.Update(CustomerBankObject);

            await _unitOfWork.Complete();

            return TransactionAdd.Id;
        }
    }
}
