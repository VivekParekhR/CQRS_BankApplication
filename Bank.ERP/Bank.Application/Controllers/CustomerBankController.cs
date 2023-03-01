#region Using
using Bank.Application.SystemActors.AccountFeature.Command;
using Bank.Application.SystemActors.AccountFeature.Query;
using Bank.Application.SystemActors.TransectionFeature.Command;
using Bank.Core.Entity;
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
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator"></param>
        public CustomerBankController(IMediator mediator)
        {
            _mediator = mediator;
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
