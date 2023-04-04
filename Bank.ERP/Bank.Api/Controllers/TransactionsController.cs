#region Using
using Bank.Core.Modules.TransectionFeature.GetTransactionById;
using Bank.Core.Modules.TransectionFeature.GetTransactionHistoryByAccountNumber;
using Bank.Core.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc; 
#endregion

namespace Bank.Api.Controllers
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
        /// <returns>transactionHistoryViewModel object</returns>
        /// <response code="200">Successfully return transactionHistoryViewModel.</response>
        /// <response code="404">TransactionHistoryViewModel object not found.</response>  
        /// <response code="500">Internal server error.</response>  
        [HttpGet("GetTransactionHistory/{CustomerId}/{BankId}")]
        [ProducesResponseType(typeof(TransactionHistoryViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetTransactionHistoryByCustomerAndBankId(int CustomerId, int BankId)
        {
            var transactionHistory =  await _mediator.Send(new GetTransactionHistoryByAccountNumberQuery { BankId = BankId, CustomerId = CustomerId });

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
        /// <returns>transaction object</returns>
        /// <response code="200">Successfully return transaction.</response>
        /// <response code="404">Transaction object not found.</response>  
        /// <response code="500">Internal server error.</response>  
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Domain.Entity.Transaction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
