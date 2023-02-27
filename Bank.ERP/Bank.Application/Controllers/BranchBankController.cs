#region MyRegion
using Bank.Application.SystemActors.BankFeature.Command;
using Bank.Application.SystemActors.BankFeature.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc; 
#endregion

namespace Bank.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchBankController : ControllerBase
    {
        #region Property
        private readonly IMediator _mediator; 
        #endregion

        /// <summary>
        /// Consturctor
        /// </summary>
        /// <param name="mediator"></param>
        public BranchBankController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// CreateBank
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateBank(CreateBankCommand command)
        {
            var bankId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetBankById), new { id = bankId }, bankId);
        }

        /// <summary>
        /// GetBankById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
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
