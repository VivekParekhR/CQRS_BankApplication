#region Using
using Bank.Application.SystemActors.BankFeature.Command;
using Bank.Core.Interface;
using Bank.Infrastructure.Enum;
using MediatR;

#endregion
namespace Bank.Application.SystemActors.BankFeature.CommandHandler
{
    public class CreateBankCommandHandler : IRequestHandler<CreateBankCommand, int>
    {
        #region Property
        private readonly IBankRepository _repository; 
        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="repository"></param>
        public CreateBankCommandHandler(IBankRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handle CreateBankCommandHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {
            var bank = new Bank.Core.Entity.Bank
            {
                Name = request.Name,
                BranchId = request.BranchId,
                CreatedById = Convert.ToInt32(SystemUser.Admin),
                CreatedDate = System.DateTime.Now
            };

            await _repository.AddBankAsync(bank);
            return bank.Id;
        }
    }
}
