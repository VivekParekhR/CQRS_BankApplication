#region Using
using Bank.Core.Interface;
using FluentValidation;
using Bank.Core.Modules.CustomerFeature.CreateCustomer;
#endregion

namespace Bank.Core.Validators
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
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.Email).EmailAddress().NotEmpty(); 
            RuleFor(c => c.Email).Must((o, Email) => { return _repository.CheckEmailWithPhoneExists(Email, o.PhoneNo); })
                                 .WithMessage("Customer with this Email and Phone already exists, Please Try with different Email or diff phone.");

        }
    }
}
