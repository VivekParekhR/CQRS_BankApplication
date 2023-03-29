#region Using
using Bank.Core.Interface;
using FluentValidation;
using Bank.Core.Modules.CustomerBankFeature.CustomerBankCreate;
#endregion

namespace Bank.Application.Validators
{
    public class CreateAccountCommandValidator : AbstractValidator<CustomerBankCreateCommand>
    {
        #region Property
        private readonly ICustomerBankRepository _repository;
        #endregion

        /// <summary>
        /// CreateAccountCommandValidator
        /// </summary>
        /// <param name="repository"></param>
        public CreateAccountCommandValidator(ICustomerBankRepository repository)
        {
            _repository = repository; 
            RuleFor(c => c.Balance).GreaterThanOrEqualTo(1);
            RuleFor(c => c.CustomerId).NotEmpty().NotEqual(0).Must((o, CustomerId) => { return _repository.CheckCustomerWithSameAccountTypeExists(CustomerId, o.AccountType,o.BankId); })
                                 .WithMessage("Either Customer not exists Or Customer with this AccountType already exists, Please Try with different AccountType And Customer.");
        }
    }
}
