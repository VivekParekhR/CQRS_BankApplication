#region Using
using Bank.Core.Interface;
using Bank.Domain.Entity;
using Bank.Domain.Enum;
using Bank.Domain.Interface;
using MediatR;
#endregion

namespace Bank.Core.Modules.CustomerFeature.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        #region Property
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }

        /// <summary>
        /// Handle CreateCustomerCommandHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNo = request.PhoneNo,
                Email = request.Email,
                IsDeleted = false,
                CreatedById = Convert.ToInt32(SystemUser.Admin),
                CreatedDate = DateTime.Now
            };

            await _unitOfWork.CustomerService.Add(customer);
            _unitOfWork.Complete();  
            return customer.Id;
        }
    }

}
