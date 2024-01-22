
using Application.HomeDetails.Commands.Request;
using Application.HomeDetails.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateHomeCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var blog = new GetAllHomeQueryRequest();
            var response = await _mediator.Send(blog);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var requestModel = new GetByIdHomeQueryRequest { Id = id };
            var blog = await _mediator.Send(requestModel);
            return blog != null
                ? (IActionResult)Ok(blog)
                : NotFound(new { Message = "Not found." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateHomeCommandRequest request)
        {

            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] DeleteHomeCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return response != null
           ? (IActionResult)Ok(response)
           : NotFound(new { Message = "Not found." });
        }
    }
}