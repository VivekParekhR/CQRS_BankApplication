#region Using
using Bank.Core.Interface;
using Bank.Domain.Enum;
using MediatR;
#endregion

namespace Bank.Core.Modules.BranchFeature.CreateBranch
{
    public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, int>
    {
        #region Property
        private readonly IBranchRepository _repository;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public CreateBranchCommandHandler(IBranchRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handle CreateBranchCommandHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = new Domain.Entity.Branch
            {
                Name = request.Name,
                BranchCode = request.BranchCode,
                CreatedById = Convert.ToInt32(SystemUser.Admin),
                CreatedDate = DateTime.Now
            };

            await _repository.AddBranchAsync(branch);
            return branch.Id;
        }
    }
}
