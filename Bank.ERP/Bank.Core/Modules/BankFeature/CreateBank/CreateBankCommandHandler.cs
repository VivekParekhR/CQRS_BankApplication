#region Using
using Bank.Core.Modules.BankFeature.CreateBank;
using Bank.Core.Interface;
using Bank.Domain.Enum;
using MediatR;

#endregion
namespace Bank.Core.Modules.Bank.CreateBank
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
            var bank = new Domain.Entity.Bank
            {
                Name = request.Name,
                BranchId = request.BranchId,
                CreatedById = Convert.ToInt32(SystemUser.Admin),
                CreatedDate = DateTime.Now
            };

            await _repository.AddBankAsync(bank);
            return bank.Id;
        }
    }
}
