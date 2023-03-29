#region Using
using Bank.Core.Modules.CustomerFeature.CreateCustomer;
using Bank.Core.Modules.CustomerFeature.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
#endregion

namespace Bank.Application.Controllers
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
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommand command)
        {
            var customerId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetCustomerById), new { id = customerId }, customerId);
        }

        /// <summary>
        /// GetCustomerById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
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
