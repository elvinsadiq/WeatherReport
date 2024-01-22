using Application.AppUserCartDetails.Commands.Request;
using Application.CheckoutDetails.Commands.Request;
using Application.CheckoutDetails.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CheckoutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOrderCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok();
            }

            return BadRequest(new { Message = "Checkout creation failed." });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var checkouts = await _mediator.Send(new GetAllOrderQueryRequest());

            return Ok(checkouts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var requestModel = new GetByIdOrderQueryRequest { Id = id };
            var checkout = await _mediator.Send(requestModel);

            return checkout != null
                ? (IActionResult)Ok(checkout)
                : NotFound(new { Message = "Checkout not found." });
        }


        [HttpPost("ClearCart")]
        public async Task<IActionResult> ClearUserCart([FromBody] ClearAppUserCartCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = response.Message });
            }

            return BadRequest(new { Message = response.Message });
        }
    }
}