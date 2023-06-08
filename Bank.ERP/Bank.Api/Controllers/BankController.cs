#region MyRegion
using Bank.Api.ResponseType;
using Bank.Core.Modules.BankFeature.CreateBank;
using Bank.Core.Modules.BankFeature.GetBankById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
#endregion

namespace Bank.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankController : ControllerBase
    {
        #region Property
        private readonly IMediator _mediator; 
        #endregion

        /// <summary>
        /// Consturctor
        /// </summary>
        /// <param name="mediator"></param>
        public BankController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// CreateBank
        /// </summary>
        /// <param name="command"></param> 
        /// <response code="201">Successfully created and redirect to action.</response>
        /// <response code="400">One or more validation errors have occurred.</response> 
        /// <response code="500">Internal server error.</response>  
        [HttpPost]
        [ProducesResponseType(typeof(RedirectResponse<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBank(CreateBankCommand command)
        {
            var bankId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetBankById), new { id = bankId }, bankId);
        }

        /// <summary>
        /// GetBankById
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bank object</returns>
        /// <response code="200">Successfully return bank object.</response>
        /// <response code="400">One or more validation errors have occurred.</response> 
        /// <response code="404">Bank object not found.</response>  
        /// <response code="500">Internal server error.</response>  
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Domain.Entity.Bank), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetBankById(int id)
        {
            var bank = await _mediator.Send(new GetBankByIdQuery { Id = id });

            if (bank == null)
            {
            
                return NotFound();
            }

            return Ok(bank);
        }
    }
}
