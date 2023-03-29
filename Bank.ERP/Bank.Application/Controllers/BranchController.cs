#region Using
using Bank.Core.Modules.BranchFeature.CreateBranch;
using Bank.Core.Modules.BranchFeature.GetBranchById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
#endregion

namespace Bank.Application.Controllers
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
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateBranch(CreateBranchCommand command)
        {
            var branchId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetBranchById), new { id = branchId }, branchId);
        }

        /// <summary>
        /// GetBranchById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
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
