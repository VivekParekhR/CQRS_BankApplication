#region Using
using Bank.Core.Interface;
using Bank.Domain.Enum;
using Bank.Domain.Interface;
using MediatR;
#endregion

namespace Bank.Core.Modules.BranchFeature.CreateBranch
{
    public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, int>
    {
        #region Property
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        public CreateBranchCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

            await _unitOfWork.BranchService.Add(branch);
            _unitOfWork.Complete();
            return branch.Id;
        }
    }
}
