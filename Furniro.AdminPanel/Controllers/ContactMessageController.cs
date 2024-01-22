using Application.ContactMessageDetails.Commands.Request;
using Application.ContactMessageDetails.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ContactMessageController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContactMessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteContactMessageCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return response.IsSuccess
                ? Ok(new { Message = "Contact message deleted successfully." })
                : throw new Exception();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllContactMessageQueryRequest());
            return Ok(response);
        }
    }
}