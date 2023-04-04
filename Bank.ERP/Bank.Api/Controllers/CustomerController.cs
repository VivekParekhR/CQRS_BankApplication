#region Using
using Bank.Api.ResponseType;
using Bank.Core.Modules.CustomerFeature.CreateCustomer;
using Bank.Core.Modules.CustomerFeature.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
#endregion

namespace Bank.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        #region Property
        private readonly IMediator _mediator; 
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator"></param>
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// CreateCustomer
        /// </summary>
        /// <param name="command"></param>
        /// <response code="201">Successfully created and redirect to action.</response>
        /// <response code="400">One or more validation errors have occurred.</response> 
        /// <response code="500">Internal server error.</response>  
        [HttpPost]
        [ProducesResponseType(typeof(RedirectResponse<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommand command)
        {
            var customerId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetCustomerById), new { id = customerId }, customerId);
        }

        /// <summary>
        /// GetCustomerById
        /// </summary>
        /// <param name="id"></param>
        /// <returns>customer object</returns> 
        /// <response code="200">Successfully return customer object.</response>
        /// <response code="400">One or more validation errors have occurred.</response> 
        /// <response code="404">Customer object not found.</response>  
        /// <response code="500">Internal server error.</response>  
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Domain.Entity.Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetCustomerById(int id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery { Id = id });

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
    }
}
