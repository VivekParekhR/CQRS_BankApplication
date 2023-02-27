#region Using
using Bank.Application.SystemActors.AccountFeature.Command;
using Bank.Application.SystemActors.AccountFeature.Query;
using Bank.Application.SystemActors.TransectionFeature.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc; 
#endregion

namespace Bank.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerAccountController : ControllerBase
    {
        #region Property
        private readonly IMediator _mediator; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator"></param>
        public CustomerAccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// OpenAccount
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("OpenAccount")]
        public async Task<IActionResult> OpenAccount(CreateAccountCommand command)
        {
            var accountId = await _mediator.Send(command);

            return CreatedAtAction(nameof(CheckBalance), new { id = accountId }, accountId);
        }

        /// <summary>
        /// TransferPayment
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("TransferPayment")]
        public async Task<IActionResult> TransferPayment(TransferCommand command)
        {
            var transactionId = await _mediator.Send(command);

            return Ok(transactionId);
        }

        /// <summary>
        /// CheckBalance
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("CheckBalance/{id}")]
        public async Task<ActionResult> CheckBalance(int id)
        {
            var account = await _mediator.Send(new GetAccountByIdQuery { Id = id });

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }
    }
}
