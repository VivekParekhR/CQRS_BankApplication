#region Using
using Bank.Domain.Interface;
using MediatR;
#endregion

namespace Bank.Core.Modules.BranchFeature.GetBranchById
{
    public class GetBranchByIdQueryHandler : IRequestHandler<GetBranchByIdQuery, Domain.Entity.Branch>
    {
        #region Property
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        public GetBranchByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Handle  GetBranchByIdQueryHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Domain.Entity.Branch> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            return await  _unitOfWork.BranchService.GetById(request.Id);
        }
    }
}
