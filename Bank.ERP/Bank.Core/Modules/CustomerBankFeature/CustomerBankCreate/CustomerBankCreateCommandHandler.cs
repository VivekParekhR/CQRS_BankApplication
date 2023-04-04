#region Using
using Bank.Core.Interface;
using Bank.Domain.Entity;
using Bank.Domain.Enum;
using Bank.Domain.Interface;
using MassTransit;
using MediatR;
#endregion

namespace Bank.Core.Modules.CustomerBankFeature.CustomerBankCreate
{
    public class CustomerBankCreateCommandHandler : IRequestHandler<CustomerBankCreateCommand, int>
    {
        #region Property
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        public CustomerBankCreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                CreatedDate = DateTime.Now
            };

            await _unitOfWork.CustomerBankService.Add(account);
            _unitOfWork.Complete(); 
            return account.Id;
        }
    }
}
