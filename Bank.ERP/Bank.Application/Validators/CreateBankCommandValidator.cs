#region Using
using Bank.Application.SystemActors.BankFeature.Command;
using Bank.Core.Interface;
using FluentValidation;
#endregion

namespace Bank.Application.Validators
{
    public class CreateBankCommandValidator: AbstractValidator<CreateBankCommand>
    {
        #region Property
        private readonly IBankRepository _repository;
        #endregion

        /// <summary>
        /// CreateBankCommandValidator
        /// </summary>
        /// <param name="repository"></param>
        public CreateBankCommandValidator(IBankRepository repository)
        {
            _repository = repository;
            RuleFor(c => c.BranchId).NotEqual(0);
            RuleFor(c => c.Name).NotEmpty().Must((o, Name) => { return _repository.CheckBankExists(Name, o.BranchId); })
                                 .WithMessage("Name with this Bank already exists in specific Branch, Please Try with different Name or diff branchId.");

        }


    }
}
