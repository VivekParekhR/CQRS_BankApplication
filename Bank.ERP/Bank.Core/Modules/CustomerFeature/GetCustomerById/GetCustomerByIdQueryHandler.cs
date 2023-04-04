#region Using
using Bank.Core.Interface;
using Bank.Domain.Entity;
using Bank.Domain.Interface;
using MediatR;

#endregion
namespace Bank.Core.Modules.CustomerFeature.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        #region Property
        private readonly IUnitOfWork _unitOfWork; 
        #endregion

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="repository"></param>
        public GetCustomerByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }

        /// <summary>
        /// Handle GetCustomerByIdQueryHandler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CustomerService.GetById(request.Id); 
        }
    }
}
