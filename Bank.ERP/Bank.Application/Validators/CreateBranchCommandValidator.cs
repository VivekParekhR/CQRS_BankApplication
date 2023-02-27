#region Using
using Bank.Application.SystemActors.BranchFeature.Command;
using Bank.Core.Interface;
using FluentValidation; 
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
