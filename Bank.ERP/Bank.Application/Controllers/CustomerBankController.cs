#region Using
using Bank.Core.Modules.CustomerBankFeature.CustomerBankCreate;
using Bank.Core.Modules.CustomerBankFeature.GetCustomerBankById;
using Bank.Core.Modules.TransectionFeature.TransferAmount;
using Bank.Shared.Common;
using Bank.Shared.ServiceMessagingObject;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
#endregion

namespace Bank.Application.Controllers
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
        /// <returns></returns>
        [HttpPost("CreateAccount")]
        public async Task<IActionResult> CustomerBankCreate(CustomerBankCreateCommand command)
        {
            var accountId = await _mediator.Send(command);

            return Ok(accountId);
        }

        /// <summary>
        /// TransferFund
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("TransferFund")]
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
        /// <returns></returns>
        [HttpGet("GetCustomerAccountBalance/{customerId}")]
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
