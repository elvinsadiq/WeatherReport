using Application.ColorDetails.Commands.Request;
using Application.ColorDetails.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ColorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateColor([FromBody] CreateColorCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = "Color created successfully." });
            }

            return BadRequest(new { Message = "Color creation failed." });
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteColor([FromBody] DeleteColorCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = "Color deleted successfully." });
            }

            return NotFound(new { Message = "Color not found or deletion failed." });
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateColor([FromBody] UpdateColorCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = "Color updated successfully." });
            }

            return BadRequest(new { Message = "Color update failed." });
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllColors([FromQuery] GetAllColorQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetColorById([FromQuery] GetByIdColorQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return response != null
            ? (IActionResult)Ok(response)
            : NotFound(new { Message = "Color not found." });
        }
    }
}
