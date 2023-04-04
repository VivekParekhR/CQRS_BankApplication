#region Using
using Bank.Core.Interface;
using FluentValidation;
using Bank.Core.Modules.BranchFeature.CreateBranch;
using Bank.Domain.Interface;
#endregion

namespace Bank.Core.Validators
{
    public class CreateBranchCommandValidator : AbstractValidator<CreateBranchCommand>
    {
        #region Property
        private readonly IUnitOfWork _unitOfWork; 
        #endregion

        /// <summary>
        /// CreateBranchCommandValidator
        /// </summary>
        /// <param name="repository"></param>
        public CreateBranchCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
            RuleFor(c => c.BranchCode).NotEmpty();
            RuleFor(c => c.Name).NotEmpty()
                  .Custom((property, context) =>
                  {
                      if (!_unitOfWork.BranchService.CheckBranchExists(property))
                      {
                          context.AddFailure($"'{property}' is already Exists. Try with other Name.");
                      }
                  });
        }


    }
}
