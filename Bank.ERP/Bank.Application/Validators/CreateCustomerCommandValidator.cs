#region Using
using Bank.Application.SystemActors.CustomerFeature.Command;
using Bank.Core.Interface;
using FluentValidation; 
#endregion

namespace Bank.Application.Validators
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        #region Property
        private readonly ICustomerRepository _repository;
        #endregion

        /// <summary>
        /// CreateCustomerCommandValidator
        /// </summary>
        /// <param name="repository"></param>
        public CreateCustomerCommandValidator(ICustomerRepository repository)
        {
            _repository = repository;
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Email).EmailAddress().NotEmpty();
            RuleFor(c => c.BankId).NotEmpty().NotEqual(0);
            RuleFor(c => c.Email).Must((o, Email) => { return _repository.CheckEmailWithBankExists(Email, o.BankId); })
                                 .WithMessage("Email with this Bank already exists, Please Try with different Email or diff Bank.");

        }
    }
}
