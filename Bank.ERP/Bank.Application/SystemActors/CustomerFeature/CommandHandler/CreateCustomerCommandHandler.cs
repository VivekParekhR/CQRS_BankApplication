#region Using
using Bank.Application.SystemActors.CustomerFeature.Command;
using Bank.Core.Entity;
using Bank.Core.Interface;
using MediatR; 
#endregion

namespace Bank.Application.SystemActors.CustomerFeature.CommandHandler
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        #region Property
        private readonly ICustomerRepository _repository; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public CreateCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
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
                Name = request.Name,
                Email = request.Email,
                BankId = request.BankId
            };

            await _repository.AddCustomerAsync(customer);
            return customer.Id;
        }
    }

}
