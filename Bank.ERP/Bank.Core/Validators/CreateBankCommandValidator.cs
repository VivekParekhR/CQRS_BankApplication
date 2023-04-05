#region Using
using FluentValidation;
using Bank.Core.Modules.BankFeature.CreateBank;
using Bank.Domain.Interface;
#endregion

namespace Bank.Core.Validators
{
    public class CreateBankCommandValidator: AbstractValidator<CreateBankCommand>
    {
        #region Property
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        /// <summary>
        /// CreateBankCommandValidator
        /// </summary>
        /// <param name="unitOfWork"></param>
        public CreateBankCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(c => c.BranchId).NotEqual(0);
            RuleFor(c => c.Name).NotEmpty().Must((o, Name) => { return _unitOfWork.BankService.CheckBankExists(Name, o.BranchId); })
                                 .WithMessage("Name with this Bank already exists in specific Branch, Please Try with different Name or diff branchId.");

        }


    }
}
