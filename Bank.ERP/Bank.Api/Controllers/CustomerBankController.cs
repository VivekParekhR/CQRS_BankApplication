#region Using
using Bank.Core.Constant;
using Bank.Core.Modules.CustomerBankFeature.CustomerBankCreate;
using Bank.Core.Modules.CustomerBankFeature.GetCustomerBankById;
using Bank.Core.Modules.TransectionFeature.TransferAmount;
using Bank.Core.ViewModel; 
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
#endregion

namespace Bank.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerBankController : ControllerBase
    {
        #region Property
        private readonly IMediator _mediator;
        private readonly IBus _bus;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator"></param>
        public CustomerBankController(IMediator mediator, IBus bus)
        {
            _mediator = mediator;
            _bus = bus;
        }

        /// <summary>
        /// OpenAccount
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Customerbank id</returns>
        /// <response code="200">Successfully return customerbank id.</response>
        /// <response code="400">One or more validation errors have occurred.</response> 
        /// <response code="500">Internal server error.</response>  
        [HttpPost("CreateAccount")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CustomerBankCreate(CustomerBankCreateCommand command)
        {
            var accountId = await _mediator.Send(command);

            return Ok(accountId);
        }

        /// <summary>
        /// TransferFund
        /// </summary>
        /// <param name="command"></param>
        /// <returns>bank object</returns>
        /// <response code="200">Successfully return transactionId.</response>
        /// <response code="400">One or more validation errors have occurred.</response> 
        /// <response code="404">Bank object not found.</response>  
        /// <response code="500">Internal server error.</response>  
        [HttpPost("TransferFund")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> TransferFund(TransferCommand command)
        {
           
            var transactionId = await _mediator.Send(command);
           
            Uri uri = new Uri("rabbitmq://localhost/"+ ERPConstant.RabbitMQ_EmailQueue);

            var endPoint = await _bus.GetSendEndpoint(uri);

            EmailNotification objEmailNotification = new EmailNotification();
            
            objEmailNotification.Subject = "Transfer Fund From Bank : "+ command.BankId;
            objEmailNotification.Body = "Frund Transfer Time :" + objEmailNotification.MessageForQueueGenerationTime + " <br/>" +
                                        "Amount :" + command.Amount + " <br/>"  +
                                        "TransectionRemarks :" + command.TransectionRemarks + " <br/>" +
                                        "For Referance Transection Id is :" + transactionId;
            objEmailNotification.FromAddress = ERPConstant.FromEmail;
            objEmailNotification.ToAddress = ERPConstant.ToEmail;
            objEmailNotification.PhonNo = ERPConstant.PhonNo;
            await endPoint.Send(objEmailNotification);
            return Ok(transactionId);
        }

        /// <summary>
        /// GetCustomerAccountBalance
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List<CustomerBankViewModel> list</returns>
        /// <response code="200">Successfully return List<CustomerBankViewModel>.</response> 
        /// <response code="404">List<CustomerBankViewModel> list is not found.</response>  
        /// <response code="500">Internal server error.</response>  
        [HttpGet("GetCustomerAccountBalance/{customerId}")]
        [ProducesResponseType(typeof(List<CustomerBankViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetCustomerAccountBalance(int customerId)
        {
            var account = await _mediator.Send(new GetCustomerBankByIdQuery { CustomerId = customerId });

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }
    }
}
