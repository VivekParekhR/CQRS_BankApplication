#region Using
using Bank.Domain.Interface;
using MediatR;
#endregion

namespace Bank.Core.Modules.BankFeature.GetBankById
{
    public class GetBankByIdQueryHandler : IRequestHandler<GetBankByIdQuery, Domain.Entity.Bank>
    {
        #region Property
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        public GetBankByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Handle GetBankByIdQueryHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Domain.Entity.Bank> Handle(GetBankByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.BankService.GetById(request.Id);
        }
    }
}
