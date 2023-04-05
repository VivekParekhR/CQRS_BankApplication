#region Using
using Azure.Core;
using Bank.Core.Constant;
using Bank.Core.EventBus;
using Bank.Core.ViewModel;
using Bank.Domain.Entity;
using Bank.Domain.Enum;
using Bank.Domain.Exceptions;
using Bank.Domain.Interface;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

#endregion
namespace Bank.Core.Modules.TransectionFeature.TransferAmount
{
    public class TransferCommandHandler : IRequestHandler<TransferCommand, int>
    {
        #region Property
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventBusProvider _IEventBusProvider;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bankRepository"></param>
        public TransferCommandHandler(IUnitOfWork unitOfWork, IEventBusProvider IEventBusProvider)
        {
            _unitOfWork = unitOfWork;
            _IEventBusProvider = IEventBusProvider;
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

            var TransactionAdd = new Domain.Entity.Transaction
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

            RaiseDomainEvent(TransactionAdd, CustomerBankObject);
             
            await _unitOfWork.TransactionService.Add(TransactionAdd);

            _unitOfWork.CustomerBankService.Update(CustomerBankObject);

            await _unitOfWork.Complete();

            await RaiseEmailEvent(TransactionAdd);

            return TransactionAdd.Id;
        }

        /// <summary>
        /// RaiseDomainEvent
        /// </summary>
        /// <param name="TransactionAdd"></param>
        /// <param name="CustomerBankObject"></param>
        private void RaiseDomainEvent(Domain.Entity.Transaction TransactionAdd, CustomerBank CustomerBankObject) {
            Domain.Entity.Transaction.RaiseEvent(new Domain.Events.TransactionCreatedDomainEvent
            {
                Transaction = TransactionAdd,
                CustomerBank = CustomerBankObject
            });
        }

        /// <summary>
        /// RaiseEmailEvent
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private async Task RaiseEmailEvent(Domain.Entity.Transaction command) {

            EmailNotification objEmailNotification = new EmailNotification();

            objEmailNotification.Subject = "Transfer Fund From Bank : " + command.BankId;
            objEmailNotification.Body = "Frund Transfer Time :" + objEmailNotification.MessageForQueueGenerationTime + " <br/>" +
            "Amount :" + command.Amount + " <br/>" +
                                        "TransectionRemarks :" + command.TransectionRemarks + " <br/>" +
                                        "For Referance Transection Id is :" + command.Id;
            objEmailNotification.FromAddress = ERPConstant.FromEmail;
            objEmailNotification.ToAddress = ERPConstant.ToEmail;
            objEmailNotification.PhonNo = ERPConstant.PhonNo;
            await _IEventBusProvider.publishEmailEventAsync(objEmailNotification);
        }
    }
}
