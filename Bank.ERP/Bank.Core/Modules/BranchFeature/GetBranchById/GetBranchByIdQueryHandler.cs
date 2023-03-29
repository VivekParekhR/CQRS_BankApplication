#region Using
using Bank.Core.Interface;
using MediatR;
#endregion

namespace Bank.Core.Modules.BranchFeature.GetBranchById
{
    public class GetBranchByIdQueryHandler : IRequestHandler<GetBranchByIdQuery, Domain.Entity.Branch>
    {
        #region Property
        private readonly IBranchRepository _repository;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public GetBranchByIdQueryHandler(IBranchRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handle  GetBranchByIdQueryHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Domain.Entity.Branch> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetBranchByIdAsync(request.Id);
        }
    }
}
