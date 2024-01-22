using Application.SizeDetails.Commands.Request;
using Application.SizeDetails.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.AdminPanel.Controllers
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateSize([FromBody] CreateSizeCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = "Size created successfully." });
            }

            return BadRequest(new { Message = "Size creation failed." });
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteSize([FromBody] DeleteSizeCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = "Size deleted successfully." });
            }

            return NotFound(new { Message = "Size not found or deletion failed." });
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateColor([FromBody] UpdateSizeCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = "Size updated successfully." });
            }

            return BadRequest(new { Message = "Size update failed." });
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
