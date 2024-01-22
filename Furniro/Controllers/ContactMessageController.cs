using Application.Commands.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "AppUser")]
    public class ContactMessageController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContactMessageController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateContactMessageCommandRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.IsSuccess)
            {
                return Ok(new { Message = "Contact message created successfully." });
            }
            throw new Exception();
        }
    }
}