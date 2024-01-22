using Application.SizeDetails.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SizeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllSizes([FromQuery] GetAllSizeQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetColorById([FromQuery] GetByIdSizeQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return response != null
            ? (IActionResult)Ok(response)
            : NotFound(new { Message = "Size not found." });
        }
    }
}