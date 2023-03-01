#region Using
using Bank.Application.SystemActors.TransectionFeature.Query; 
using MediatR;
using Microsoft.AspNetCore.Mvc; 
#endregion

namespace Bank.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        #region Property
        private readonly IMediator _mediator; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator"></param>
        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // need to do some generic type 
        /// <summary>
        /// GetTransactionHistoryByAccountId
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        [HttpGet("GetTransectionHistory/{CustomerId}/{BankId}")]
        public async Task<ActionResult> GetTransactionHistoryByCustomerAndBankId(int CustomerId, int BankId)
        {
            var transactionHistory = await _mediator.Send(new GetTransactionHistoryByAccountNumberQuery { BankId = BankId, CustomerId = CustomerId });

            if (transactionHistory == null)
            {
                return NotFound();
            }

            return Ok(transactionHistory);
        }


        /// <summary>
        /// GetTransactionById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTransactionById(int id)
        {
            var transaction = await _mediator.Send(new GetTransactionByIdQuery { Id = id });

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

       
    }
}
