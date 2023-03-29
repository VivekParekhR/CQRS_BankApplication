#region Using
using Bank.Core.Interface;
using FluentValidation;
using Bank.Core.Modules.BranchFeature.CreateBranch;
#endregion

namespace Bank.Application.Validators
{
    public class CreateBranchCommandValidator : AbstractValidator<CreateBranchCommand>
    {
        #region Property
        private readonly IBranchRepository _repository;
        #endregion

        /// <summary>
        /// CreateBranchCommandValidator
        /// </summary>
        /// <param name="repository"></param>
        public CreateBranchCommandValidator(IBranchRepository repository)
        {
            _repository = repository;
            RuleFor(c => c.BranchCode).NotEmpty();
            RuleFor(c => c.Name).NotEmpty()
                  .Custom((property, context) =>
                  {
                      if (!_repository.CheckBranchExists(property))
                      {
                          context.AddFailure($"'{property}' is already Exists. Try with other Name.");
                      }
                  });
        }


    }
}
