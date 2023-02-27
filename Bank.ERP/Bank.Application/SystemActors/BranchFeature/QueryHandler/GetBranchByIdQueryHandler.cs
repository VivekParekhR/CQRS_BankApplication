#region Using
using Bank.Application.SystemActors.BranchFeature.Query;
using Bank.Core.Interface;
using MediatR; 
#endregion

namespace Bank.Application.SystemActors.BranchFeature.QueryHandler
{
    public class GetBranchByIdQueryHandler : IRequestHandler<GetBranchByIdQuery, Bank.Core.Entity.Branch>
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
        public async Task<Bank.Core.Entity.Branch> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetBranchByIdAsync(request.Id);
        }
    }
}
