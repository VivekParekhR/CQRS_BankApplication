#region Using
using Bank.Core.Modules.BankFeature.CreateBank;
using Bank.Domain.Enum;
using MediatR;
using Bank.Domain.Interface;

#endregion
namespace Bank.Core.Modules.Bank.CreateBank
{
    public class CreateBankCommandHandler : IRequestHandler<CreateBankCommand, int>
    {
        #region Property
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        public CreateBankCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Handle CreateBankCommandHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {
            var bank = new Domain.Entity.Bank
            {
                Name = request.Name,
                BranchId = request.BranchId,
                CreatedById = Convert.ToInt32(SystemUser.Admin),
                CreatedDate = DateTime.Now
            };


            Domain.Entity.Bank.RaiseEvent(new Domain.Events.BankCreatedDomainEvent
            {
                Bank = bank
            });

            await _unitOfWork.BankService.Add(bank);
            await _unitOfWork.Complete();
            return bank.Id;
        }
    }
}
