using Application.SizeDetails.Commands.Request;
using Application.SizeDetails.Queries.Request;
using Application.TagDetails.Commands.Request;
using Application.TagDetails.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.Controllers
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
