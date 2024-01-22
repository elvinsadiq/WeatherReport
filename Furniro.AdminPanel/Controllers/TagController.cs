using Application.TagDetails.Commands.Request;
using Application.TagDetails.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTag([FromBody] CreateTagCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = "Tag created successfully." });
            }

            return BadRequest(new { Message = "Tag creation failed." });
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteTag([FromBody] DeleteTagCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = "Tag deleted successfully." });
            }

            return NotFound(new { Message = "Tag not found or deletion failed." });
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTag([FromBody] UpdateTagCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = "Tag updated successfully." });
            }

            return BadRequest(new { Message = "Tag update failed." });
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllTags([FromQuery] GetAllTagQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetTagById([FromQuery] GetByIdTagQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return response != null
            ? (IActionResult)Ok(response)
            : NotFound(new { Message = "Tag not found." });
        }
    }
}
