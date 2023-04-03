﻿#region Using
using Azure.Core;
using Bank.Core.Exceptions;
using Bank.Core.Interface;
using Bank.Domain.Entity;
using Bank.Domain.Enum;
using MediatR;

#endregion
namespace Bank.Core.Modules.TransectionFeature.TransferAmount
{
    public class TransferCommandHandler : IRequestHandler<TransferCommand, int>
    {
        #region Property
        private readonly ICustomerBankRepository _customerBankRepository;
        private readonly ITransactionRepository _transactionRepository;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bankRepository"></param>
        public TransferCommandHandler(ICustomerBankRepository customerBankRepository,
                                      ITransactionRepository transactionRepository)
        {
            _customerBankRepository = customerBankRepository;
            _transactionRepository = transactionRepository;
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
            var CustomerBankObject = await _customerBankRepository.GetCustomerBankByBankIdAndCustomerIdAsync(command.CustomerId);

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
            var retValue = await _transactionRepository.AddTransactionAsync(TransactionAdd);

            CustomerBankObject.Balance = command.TransactionType == TransactionType.Deposite ?
                                            CustomerBankObject.Balance + command.Amount :
                                                CustomerBankObject.Balance - command.Amount;

            await _customerBankRepository.UpdateCustomerBankAsync(CustomerBankObject);

            return retValue;
        }
    }
}