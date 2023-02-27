#region Using
using Bank.Application.SystemActors.AccountFeature.Command;
using Bank.Core.Interface;
using FluentValidation; 
#endregion

namespace Bank.Application.Validators
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        #region Property
        private readonly IAccountRepository _repository;
        #endregion

        /// <summary>
        /// CreateAccountCommandValidator
        /// </summary>
        /// <param name="repository"></param>
        public CreateAccountCommandValidator(IAccountRepository repository)
        {
            _repository = repository; 
            RuleFor(c => c.Balance).GreaterThanOrEqualTo(1);
            RuleFor(c => c.CustomerId).NotEmpty().NotEqual(0).Must((o, CustomerId) => { return _repository.CheckCustomerWithSameAccountTypeExists(CustomerId, o.AccountType); })
                                 .WithMessage("Either Customer not exists Or Customer with this AccountType already exists, Please Try with different AccountType And Customer.");
        }
    }
}
