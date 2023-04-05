#region Using
using FluentValidation;
using Bank.Core.Modules.CustomerBankFeature.CustomerBankCreate;
using Bank.Domain.Interface;
#endregion

namespace Bank.Core.Validators
{
    public class CreateAccountCommandValidator : AbstractValidator<CustomerBankCreateCommand>
    {
        #region Property
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        /// <summary>
        /// CreateAccountCommandValidator
        /// </summary>
        /// <param name="unitOfWork"></param>
        public CreateAccountCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
            RuleFor(c => c.Balance).GreaterThanOrEqualTo(1);
            RuleFor(c => c.CustomerId).NotEmpty().NotEqual(0).Must((o, CustomerId) => { return _unitOfWork.CustomerBankService.CheckCustomerWithSameAccountTypeExists(CustomerId, o.AccountType,o.BankId); })
                                 .WithMessage("Either Customer not exists Or Customer with this AccountType already exists, Please Try with different AccountType And Customer.");
        }
    }
}
