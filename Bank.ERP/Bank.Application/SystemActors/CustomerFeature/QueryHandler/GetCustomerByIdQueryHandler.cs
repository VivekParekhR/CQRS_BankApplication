#region Using
using Bank.Application.SystemActors.CustomerFeature.Query;
using Bank.Core.Entity;
using Bank.Core.Interface;
using MediatR;

#endregion
namespace Bank.Application.SystemActors.CustomerFeature.QueryHandler
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        #region Property
        private readonly ICustomerRepository _repository; 
        #endregion

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="repository"></param>
        public GetCustomerByIdQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handle GetCustomerByIdQueryHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCustomerByIdAsync(request.Id);
        }
    }
}
