#region Using
using Bank.Api.ResponseType;
using Bank.Core.Modules.BranchFeature.CreateBranch;
using Bank.Core.Modules.BranchFeature.GetBranchById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
#endregion

namespace Bank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        #region Property
        private readonly IMediator _mediator; 
        #endregion

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="mediator"></param>
        public BranchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// CreateBranch
        /// </summary>
        /// <param name="command"></param> 
        /// <response code="201">Successfully created and redirect to action.</response>
        /// <response code="400">One or more validation errors have occurred.</response> 
        /// <response code="500">Internal server error.</response>  
        [HttpPost]
        [ProducesResponseType(typeof(RedirectResponse<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBranch(CreateBranchCommand command)
        {
            var branchId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetBranchById), new { id = branchId }, branchId);
        }

        /// <summary>
        /// GetBranchById
        /// </summary>
        /// <param name="id"></param>
        /// <returns>branch object</returns> 
        /// <response code="200">Successfully return branch object.</response>
        /// <response code="400">One or more validation errors have occurred.</response> 
        /// <response code="404">Branch object not found.</response>  
        /// <response code="500">Internal server error.</response>  
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Domain.Entity.Branch), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetBranchById(int id)
        {
            var branch = await _mediator.Send(new GetBranchByIdQuery { Id = id });

            if (branch == null)
            {
                return NotFound();
            }

            return Ok(branch);
        }
    }
}
