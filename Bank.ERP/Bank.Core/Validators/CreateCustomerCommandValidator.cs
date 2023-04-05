#region Using
using FluentValidation;
using Bank.Core.Modules.CustomerFeature.CreateCustomer;
using Bank.Domain.Interface;
#endregion

namespace Bank.Core.Validators
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        #region Property
        private readonly IUnitOfWork _unitOfWork; 
        #endregion

        /// <summary>
        /// CreateCustomerCommandValidator
        /// </summary>
        /// <param name="repository"></param>
        public CreateCustomerCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.Email).EmailAddress().NotEmpty(); 
            RuleFor(c => c.Email).Must((o, Email) => { return _unitOfWork.CustomerService.CheckEmailWithPhoneExists(Email, o.PhoneNo); })
                                 .WithMessage("Customer with this Email and Phone already exists, Please Try with different Email or diff phone.");

        }
    }
}
